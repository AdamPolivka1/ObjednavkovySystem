--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9
-- Dumped by pg_dump version 14.9

-- Started on 2026-01-11 15:40:41

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 67325)
-- Name: amain; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA amain;


ALTER SCHEMA amain OWNER TO postgres;

--
-- TOC entry 261 (class 1255 OID 84536)
-- Name: history_table(); Type: FUNCTION; Schema: amain; Owner: postgres
--

CREATE FUNCTION amain.history_table() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
  table_name TEXT := TG_TABLE_SCHEMA || '.' || TG_TABLE_NAME || '_h';
  old_row TEXT;
BEGIN
  IF (TG_OP = 'INSERT') THEN
    old_row := row_to_json(NEW)::text; 
	EXECUTE format(
	  'INSERT INTO %I.%I (action, val, u_name) VALUES (%L, %L, %L)',
	  TG_TABLE_SCHEMA,
	  TG_TABLE_NAME || '_h',
	  'I',
	  old_row,
	  current_user
	);
	RETURN NEW;

  ELSIF (TG_OP = 'UPDATE') THEN
    old_row := row_to_json(OLD)::text;
    EXECUTE format(
	  'INSERT INTO %I.%I (action, val, u_name) VALUES (%L, %L, %L)',
	  TG_TABLE_SCHEMA,
	  TG_TABLE_NAME || '_h',
	  'U',
	  old_row,
	  current_user
	);
    RETURN NEW;

  ELSIF (TG_OP = 'DELETE') THEN
    old_row := row_to_json(OLD)::text;
    EXECUTE format(
	  'INSERT INTO %I.%I (action, val, u_name) VALUES (%L, %L, %L)',
	  TG_TABLE_SCHEMA,
	  TG_TABLE_NAME || '_h',
	  'D',
	  old_row,
	  current_user
	);
    RETURN OLD;

  END IF;

  RETURN NULL;
END;
$$;


ALTER FUNCTION amain.history_table() OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 222 (class 1259 OID 67413)
-- Name: customer_account; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.customer_account (
    customer_account_id integer NOT NULL,
    user_id integer NOT NULL,
    created_at timestamp without time zone NOT NULL,
    valid_to timestamp without time zone NOT NULL
);


ALTER TABLE amain.customer_account OWNER TO postgres;

--
-- TOC entry 227 (class 1259 OID 67491)
-- Name: customer_account_customer_account_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.customer_account ALTER COLUMN customer_account_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.customer_account_customer_account_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 231 (class 1259 OID 84445)
-- Name: customer_account_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.customer_account_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.customer_account_h OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 84444)
-- Name: customer_account_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.customer_account_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.customer_account_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 213 (class 1259 OID 67356)
-- Name: delivery; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.delivery (
    delivery_id integer NOT NULL,
    delivery_type integer NOT NULL,
    delivery_date timestamp without time zone NOT NULL,
    delivery_address character varying(255) NOT NULL,
    status integer NOT NULL,
    price_czk numeric(10,2) NOT NULL,
    note text
);


ALTER TABLE amain.delivery OWNER TO postgres;

--
-- TOC entry 3529 (class 0 OID 0)
-- Dependencies: 213
-- Name: COLUMN delivery.delivery_type; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.delivery.delivery_type IS '1 = express, 2 = 24h, 3 = basic';


--
-- TOC entry 3530 (class 0 OID 0)
-- Dependencies: 213
-- Name: COLUMN delivery.status; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.delivery.status IS '0=nedoručena, 1=doručena';


--
-- TOC entry 212 (class 1259 OID 67355)
-- Name: delivery_delivery_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.delivery ALTER COLUMN delivery_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.delivery_delivery_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 235 (class 1259 OID 84463)
-- Name: delivery_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.delivery_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.delivery_h OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 84462)
-- Name: delivery_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.delivery_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.delivery_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 211 (class 1259 OID 67348)
-- Name: order; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain."order" (
    order_id integer NOT NULL,
    payment_id integer,
    customer_account_id integer NOT NULL,
    delivery_id integer,
    total_price_czk numeric(10,2) NOT NULL,
    status integer NOT NULL,
    ordered_at timestamp without time zone NOT NULL,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain."order" OWNER TO postgres;

--
-- TOC entry 3535 (class 0 OID 0)
-- Dependencies: 211
-- Name: COLUMN "order".status; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain."order".status IS 'vytvořena (1), zpracovává se (2), připravena k odeslání (3), doručuje se (4), dokončena(5), zrušena(6)';


--
-- TOC entry 237 (class 1259 OID 84472)
-- Name: order_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.order_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.order_h OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 84471)
-- Name: order_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.order_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 229 (class 1259 OID 83870)
-- Name: order_invoice; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.order_invoice (
    order_invoice_id integer NOT NULL,
    generated_by_user_id integer NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    code_num integer NOT NULL,
    order_id integer NOT NULL,
    detail_info text
);


ALTER TABLE amain.order_invoice OWNER TO postgres;

--
-- TOC entry 239 (class 1259 OID 84481)
-- Name: order_invoice_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.order_invoice_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.order_invoice_h OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 84480)
-- Name: order_invoice_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.order_invoice_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_invoice_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 228 (class 1259 OID 83869)
-- Name: order_invoice_order_invoice_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.order_invoice ALTER COLUMN order_invoice_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_invoice_order_invoice_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 217 (class 1259 OID 67368)
-- Name: order_item; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.order_item (
    order_item_id integer NOT NULL,
    order_id integer NOT NULL,
    product_id integer NOT NULL,
    qty integer NOT NULL,
    note text
);


ALTER TABLE amain.order_item OWNER TO postgres;

--
-- TOC entry 241 (class 1259 OID 84490)
-- Name: order_item_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.order_item_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.order_item_h OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 84489)
-- Name: order_item_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.order_item_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_item_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 216 (class 1259 OID 67367)
-- Name: order_item_order_item_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.order_item ALTER COLUMN order_item_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_item_order_item_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 210 (class 1259 OID 67347)
-- Name: order_order_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain."order" ALTER COLUMN order_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.order_order_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 215 (class 1259 OID 67362)
-- Name: payment; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.payment (
    payment_id integer NOT NULL,
    payment_date date NOT NULL,
    payment_method integer NOT NULL,
    total_czk numeric(10,2) NOT NULL,
    status integer NOT NULL,
    note text
);


ALTER TABLE amain.payment OWNER TO postgres;

--
-- TOC entry 3548 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.payment_method; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.payment_method IS '0=hotově, 1=kartou, 2=dobírka';


--
-- TOC entry 3549 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.total_czk; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.total_czk IS '0 = zaplaceno vše (spárováno s objednávkou)';


--
-- TOC entry 3550 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.status; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.status IS '1 = platná, 0 = storno';


--
-- TOC entry 243 (class 1259 OID 84499)
-- Name: payment_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.payment_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.payment_h OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 84498)
-- Name: payment_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.payment_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.payment_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 214 (class 1259 OID 67361)
-- Name: payment_payment_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.payment ALTER COLUMN payment_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.payment_payment_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 223 (class 1259 OID 67422)
-- Name: product; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.product (
    product_id integer NOT NULL,
    product_category_id integer NOT NULL,
    available_qty integer NOT NULL,
    code character varying(20) NOT NULL,
    name character varying(100) NOT NULL,
    descr text,
    price_czk numeric(10,2) NOT NULL
);


ALTER TABLE amain.product OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 67431)
-- Name: product_category; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.product_category (
    product_category_id integer NOT NULL,
    category_name character varying(255) NOT NULL,
    descr text
);


ALTER TABLE amain.product_category OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 84508)
-- Name: product_category_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.product_category_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.product_category_h OWNER TO postgres;

--
-- TOC entry 244 (class 1259 OID 84507)
-- Name: product_category_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.product_category_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.product_category_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 226 (class 1259 OID 67483)
-- Name: product_category_product_category_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.product_category ALTER COLUMN product_category_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.product_category_product_category_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 247 (class 1259 OID 84517)
-- Name: product_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.product_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.product_h OWNER TO postgres;

--
-- TOC entry 246 (class 1259 OID 84516)
-- Name: product_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.product_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.product_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 225 (class 1259 OID 67482)
-- Name: product_product_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.product ALTER COLUMN product_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.product_product_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 219 (class 1259 OID 67393)
-- Name: user; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain."user" (
    user_id integer NOT NULL,
    user_role_id integer NOT NULL,
    login character(6) NOT NULL,
    password character varying(255) NOT NULL,
    firstname character varying(255) NOT NULL,
    lastname character varying(255) NOT NULL,
    email character varying(255) NOT NULL,
    company_name character varying(255) NOT NULL,
    phone_num1 character varying(50) NOT NULL,
    phone_num2 character varying(50)
);


ALTER TABLE amain."user" OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 84526)
-- Name: user_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.user_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.user_h OWNER TO postgres;

--
-- TOC entry 248 (class 1259 OID 84525)
-- Name: user_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.user_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.user_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 221 (class 1259 OID 67401)
-- Name: user_role; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.user_role (
    user_role_id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE amain.user_role OWNER TO postgres;

--
-- TOC entry 233 (class 1259 OID 84454)
-- Name: user_role_h; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.user_role_h (
    id integer NOT NULL,
    action character(1) NOT NULL,
    val text,
    u_name character varying(100) NOT NULL,
    ts timestamp without time zone DEFAULT CURRENT_TIMESTAMP
);


ALTER TABLE amain.user_role_h OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 84453)
-- Name: user_role_h_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.user_role_h ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.user_role_h_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 220 (class 1259 OID 67400)
-- Name: user_role_user_role_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain.user_role ALTER COLUMN user_role_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.user_role_user_role_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 218 (class 1259 OID 67392)
-- Name: user_user_id_seq; Type: SEQUENCE; Schema: amain; Owner: postgres
--

ALTER TABLE amain."user" ALTER COLUMN user_id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME amain.user_user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3491 (class 0 OID 67413)
-- Dependencies: 222
-- Data for Name: customer_account; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.customer_account (customer_account_id, user_id, created_at, valid_to) FROM stdin;
1	1	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
2	2	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
3	3	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
4	4	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
5	5	2025-11-15 16:46:27.044	2030-11-15 15:46:27.044
\.


--
-- TOC entry 3500 (class 0 OID 84445)
-- Dependencies: 231
-- Data for Name: customer_account_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.customer_account_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3482 (class 0 OID 67356)
-- Dependencies: 213
-- Data for Name: delivery; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.delivery (delivery_id, delivery_type, delivery_date, delivery_address, status, price_czk, note) FROM stdin;
\.


--
-- TOC entry 3504 (class 0 OID 84463)
-- Dependencies: 235
-- Data for Name: delivery_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.delivery_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3480 (class 0 OID 67348)
-- Dependencies: 211
-- Data for Name: order; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain."order" (order_id, payment_id, customer_account_id, delivery_id, total_price_czk, status, ordered_at, updated_at) FROM stdin;
19	\N	2	\N	0.00	1	2025-09-23 19:00:03.137	\N
20	\N	2	\N	0.00	1	2025-09-23 19:01:03.137	\N
21	\N	1	\N	0.00	1	2025-09-23 19:01:03.137	\N
22	\N	2	\N	0.00	1	2025-09-23 19:01:03.137	\N
24	\N	4	\N	0.00	1	2025-08-23 19:01:03.137	\N
25	\N	5	\N	0.00	1	2025-08-23 19:01:03.137	\N
26	\N	5	\N	0.00	1	2025-08-23 19:01:03.137	\N
23	\N	3	\N	0.00	1	2025-10-23 19:01:03.137	\N
27	\N	5	\N	0.00	1	2025-07-23 19:01:03.137	\N
12	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
13	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	\N
14	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	\N
15	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
16	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
17	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
18	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
28	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
29	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
30	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
31	\N	1	\N	0.00	1	2025-11-23 19:01:03.137185	\N
32	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
33	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	\N
34	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	\N
35	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
36	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
37	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
38	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
39	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
40	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
41	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
42	\N	1	\N	0.00	1	2025-11-23 19:01:03.137185	\N
43	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
44	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	\N
45	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	\N
46	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
47	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
48	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
49	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	\N
50	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
51	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
52	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	\N
11	\N	1	\N	10000.00	1	2025-11-23 19:01:03.137185	\N
\.


--
-- TOC entry 3506 (class 0 OID 84472)
-- Dependencies: 237
-- Data for Name: order_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_h (id, action, val, u_name, ts) FROM stdin;
1	U	{"order_id":19,"payment_id":null,"customer_account_id":2,"delivery_id":null,"total_price_czk":0.00,"status":1,"ordered_at":"2025-09-23T19:01:03.137","updated_at":null}	postgres	2026-01-07 21:56:07.36157
\.


--
-- TOC entry 3498 (class 0 OID 83870)
-- Dependencies: 229
-- Data for Name: order_invoice; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_invoice (order_invoice_id, generated_by_user_id, created_at, code_num, order_id, detail_info) FROM stdin;
1	1	2025-12-22 21:58:12.017604	0	11	PDFInvoiceDTO(InvoiceNumber=0000000000,InvoiceAccNum=,Date1=22.12.2025 0:00:00,Date2=21.01.2026 0:00:00,TotalPriceCZK=4000,00,Dod_Name=Firma1,Dod_Address=,Dod_IC=,Odb_Name=Jan Novak,Dod_Address=,Odb_IC=,Odb_Name=Jan Novak,Odb_Address=Hlinsko)
2	1	2025-12-22 21:58:35.671904	1	11	PDFInvoiceDTO(InvoiceNumber=0000000001,InvoiceAccNum=,Date1=22.12.2025 0:00:00,Date2=21.01.2026 0:00:00,TotalPriceCZK=4000,00,Dod_Name=Firma1,Dod_Address=,Dod_IC=,Odb_Name=Jan Novak,Dod_Address=,Odb_IC=,Odb_Name=Jan Novak,Odb_Address=Hlinsko)
3	1	2025-12-23 13:34:52.309262	2	11	PDFInvoiceDTO(InvoiceNumber=0000000002,InvoiceAccNum=,Date1=23.12.2025 0:00:00,Date2=22.01.2026 0:00:00,TotalPriceCZK=4000,00,Dod_Name=Firma1,Dod_Address=,Dod_IC=,Odb_Name=Jan Novak,Dod_Address=,Odb_IC=,Odb_Name=Jan Novak,Odb_Address=Hlinsko)
4	9	2025-12-23 16:01:17.232123	3	11	PDFInvoiceDTO(InvoiceNumber=0000000003,InvoiceAccNum=UC1,Date1=23.12.2025 0:00:00,Date2=22.01.2026 0:00:00,TotalPriceCZK=10000,00,Dod_Name=FirmaManager,Dod_Address=Adresa1,Dod_IC=111,Odb_Name=Jan Novak,Dod_Address=Adresa1,Odb_IC=222,Odb_Name=Jan Novak,Odb_Address=Hlinsko,VS=VS1)
5	9	2025-12-29 18:53:26.56127	4	11	PDFInvoiceDTO(InvoiceNumber=0000000004,InvoiceAccNum=123456-789012/0300,Date1=04.12.2025 0:00:00,Date2=01.01.2026 0:00:00,TotalPriceCZK=10000,00,Dod_Name=Firma Dodavatele,Dod_Address=Jihlava 1,Dod_IC=12345678,Odb_Name=Jan Novák,Dod_Address=Jihlava 1,Odb_IC=12345679,Odb_Name=Jan Novák,Odb_Address=Jihlava 2,VS=2025120108)
6	9	2026-01-01 18:22:17.168515	5	0	PDFInvoiceDTO(InvoiceNumber=0000000005,InvoiceAccNum=111,Date1=01.01.2026 0:00:00,Date2=31.01.2026 0:00:00,TotalPriceCZK=0,Dod_Name=FirmaManager,Dod_Address=11,Dod_IC=11,Odb_Name=1,Dod_Address=11,Odb_IC=1,Odb_Name=1,Odb_Address=1,VS=11111)
7	9	2026-01-01 18:24:38.081905	6	11	PDFInvoiceDTO(InvoiceNumber=0000000006,InvoiceAccNum=,Date1=01.01.2026 0:00:00,Date2=31.01.2026 0:00:00,TotalPriceCZK=10000,00,Dod_Name=FirmaManager,Dod_Address=,Dod_IC=,Odb_Name=Jan Novák,Dod_Address=,Odb_IC=,Odb_Name=Jan Novák,Odb_Address=,VS=)
\.


--
-- TOC entry 3508 (class 0 OID 84481)
-- Dependencies: 239
-- Data for Name: order_invoice_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_invoice_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3486 (class 0 OID 67368)
-- Dependencies: 217
-- Data for Name: order_item; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_item (order_item_id, order_id, product_id, qty, note) FROM stdin;
60	11	21	10	\N
61	11	23	5	testovací data
\.


--
-- TOC entry 3510 (class 0 OID 84490)
-- Dependencies: 241
-- Data for Name: order_item_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_item_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3484 (class 0 OID 67362)
-- Dependencies: 215
-- Data for Name: payment; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.payment (payment_id, payment_date, payment_method, total_czk, status, note) FROM stdin;
\.


--
-- TOC entry 3512 (class 0 OID 84499)
-- Dependencies: 243
-- Data for Name: payment_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.payment_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3492 (class 0 OID 67422)
-- Dependencies: 223
-- Data for Name: product; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.product (product_id, product_category_id, available_qty, code, name, descr, price_czk) FROM stdin;
22	1	130	EL-HDP-01	HDMI kabel 1.5m	High-speed HDMI kabel s podporou 4K	150.00
21	1	192	EL-USB-32	USB Flash Disk 32GB	Rychlý USB 3.0 flash disk	250.00
24	2	42	NT-KLD-SET	Sada klíčů 12 ks	Sada klíčů	600.00
23	2	22	NT-VRT-500	Aku vrtačka 500W	Akumulátorová vrtačka s dvěma bateriemi	1500.00
25	3	20	KP-PPR-A4	Papír A4 500 listů	Kancelářský papír 80g	100.00
26	3	30	KP-PEN-BL	Kuličkové pero modré	Kvalitní psací pero 1mm	10.00
27	4	5	NB-STL-01	Kancelářská židle	Ergonomická židle s opěrkou hlavy	3000.00
28	4	8	NB-STL-02	Pracovní stůl 120cm	Dřevěný pracovní stůl v dekoru dub	2000.00
29	5	45	OB-TRI-M	Tričko pánské M	Bavlněné tričko – velikost M	200.00
30	5	30	OB-MIK-L	Mikina unisex L	Mikina – velikost L	500.00
\.


--
-- TOC entry 3493 (class 0 OID 67431)
-- Dependencies: 224
-- Data for Name: product_category; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.product_category (product_category_id, category_name, descr) FROM stdin;
1	Elektronika	Elektronická zařízení a příslušenství
2	Nářadí	Ruční a elektrické nářadí
3	Kancelářské potřeby	Spotřební a psací potřeby
4	Nábytek	Domácí a kancelářský nábytek
5	Oblečení	Textilní a módní výrobky
\.


--
-- TOC entry 3514 (class 0 OID 84508)
-- Dependencies: 245
-- Data for Name: product_category_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.product_category_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3516 (class 0 OID 84517)
-- Dependencies: 247
-- Data for Name: product_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.product_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3488 (class 0 OID 67393)
-- Dependencies: 219
-- Data for Name: user; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain."user" (user_id, user_role_id, login, password, firstname, lastname, email, company_name, phone_num1, phone_num2) FROM stdin;
2	1	z00002	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Petr	Svoboda	petr.svoboda@email.com	Firma2	777888701	\N
3	1	z00003	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Eva	Dvorakova	eva.dvorakova@email.com	Firma3	777888702	\N
4	1	z00004	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Karel	Krejci	karel.krejci@email.com	Firma4	777888703	\N
5	1	z00005	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Lucie	Prochazkova	lucie.prochazkova@email.com	Firma5	777888704	\N
6	3	s00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Martin	Hruby	martin.hruby@email.com	Sklad1	777888705	\N
7	3	s00002	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Petra	Marekova	petra.marekova@email.com	Sklad2	777888706	\N
8	3	s00003	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Roman	Kovar	roman.kovar@email.com	Sklad3	777888707	\N
10	4	a00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Admin	Super	admin@email.com	FirmaAdmin	777888709	\N
9	2	m00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Jiří	Bole	jiri.bole@email.com	FirmaManager	777888708	\N
1	1	z00001	$2a$11$XQ1rZLJRxM9Noc/0lfQVhOkYn20kzXtRfe96Hg3ormsuY0fZgUMc6	Jan	Novák	jan.novak@email.com	Firma1	777888700	\N
\.


--
-- TOC entry 3518 (class 0 OID 84526)
-- Dependencies: 249
-- Data for Name: user_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.user_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3490 (class 0 OID 67401)
-- Dependencies: 221
-- Data for Name: user_role; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.user_role (user_role_id, name) FROM stdin;
3	skladník
4	administrátor
2	manažer
1	zákazník
\.


--
-- TOC entry 3502 (class 0 OID 84454)
-- Dependencies: 233
-- Data for Name: user_role_h; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.user_role_h (id, action, val, u_name, ts) FROM stdin;
\.


--
-- TOC entry 3571 (class 0 OID 0)
-- Dependencies: 227
-- Name: customer_account_customer_account_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.customer_account_customer_account_id_seq', 6, true);


--
-- TOC entry 3572 (class 0 OID 0)
-- Dependencies: 230
-- Name: customer_account_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.customer_account_h_id_seq', 4, true);


--
-- TOC entry 3573 (class 0 OID 0)
-- Dependencies: 212
-- Name: delivery_delivery_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.delivery_delivery_id_seq', 13, true);


--
-- TOC entry 3574 (class 0 OID 0)
-- Dependencies: 234
-- Name: delivery_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.delivery_h_id_seq', 1, false);


--
-- TOC entry 3575 (class 0 OID 0)
-- Dependencies: 236
-- Name: order_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_h_id_seq', 1, true);


--
-- TOC entry 3576 (class 0 OID 0)
-- Dependencies: 238
-- Name: order_invoice_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_invoice_h_id_seq', 1, false);


--
-- TOC entry 3577 (class 0 OID 0)
-- Dependencies: 228
-- Name: order_invoice_order_invoice_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_invoice_order_invoice_id_seq', 7, true);


--
-- TOC entry 3578 (class 0 OID 0)
-- Dependencies: 240
-- Name: order_item_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_item_h_id_seq', 1, false);


--
-- TOC entry 3579 (class 0 OID 0)
-- Dependencies: 216
-- Name: order_item_order_item_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_item_order_item_id_seq', 61, true);


--
-- TOC entry 3580 (class 0 OID 0)
-- Dependencies: 210
-- Name: order_order_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_order_id_seq', 63, true);


--
-- TOC entry 3581 (class 0 OID 0)
-- Dependencies: 242
-- Name: payment_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.payment_h_id_seq', 1, false);


--
-- TOC entry 3582 (class 0 OID 0)
-- Dependencies: 214
-- Name: payment_payment_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.payment_payment_id_seq', 3, true);


--
-- TOC entry 3583 (class 0 OID 0)
-- Dependencies: 244
-- Name: product_category_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_category_h_id_seq', 1, false);


--
-- TOC entry 3584 (class 0 OID 0)
-- Dependencies: 226
-- Name: product_category_product_category_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_category_product_category_id_seq', 1, false);


--
-- TOC entry 3585 (class 0 OID 0)
-- Dependencies: 246
-- Name: product_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_h_id_seq', 1, false);


--
-- TOC entry 3586 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_product_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_product_id_seq', 30, true);


--
-- TOC entry 3587 (class 0 OID 0)
-- Dependencies: 248
-- Name: user_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_h_id_seq', 1, false);


--
-- TOC entry 3588 (class 0 OID 0)
-- Dependencies: 232
-- Name: user_role_h_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_role_h_id_seq', 1, false);


--
-- TOC entry 3589 (class 0 OID 0)
-- Dependencies: 220
-- Name: user_role_user_role_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_role_user_role_id_seq', 4, true);


--
-- TOC entry 3590 (class 0 OID 0)
-- Dependencies: 218
-- Name: user_user_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_user_id_seq', 15, true);


--
-- TOC entry 3304 (class 2606 OID 84452)
-- Name: customer_account_h customer_account_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.customer_account_h
    ADD CONSTRAINT customer_account_h_pk PRIMARY KEY (id);


--
-- TOC entry 3292 (class 2606 OID 67417)
-- Name: customer_account customer_account_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.customer_account
    ADD CONSTRAINT customer_account_pk PRIMARY KEY (customer_account_id);


--
-- TOC entry 3308 (class 2606 OID 84470)
-- Name: delivery_h delivery_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.delivery_h
    ADD CONSTRAINT delivery_h_pk PRIMARY KEY (id);


--
-- TOC entry 3278 (class 2606 OID 67360)
-- Name: delivery delivery_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.delivery
    ADD CONSTRAINT delivery_pk PRIMARY KEY (delivery_id);


--
-- TOC entry 3310 (class 2606 OID 84479)
-- Name: order_h order_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_h
    ADD CONSTRAINT order_h_pk PRIMARY KEY (id);


--
-- TOC entry 3312 (class 2606 OID 84488)
-- Name: order_invoice_h order_invoice_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_invoice_h
    ADD CONSTRAINT order_invoice_h_pk PRIMARY KEY (id);


--
-- TOC entry 3300 (class 2606 OID 83886)
-- Name: order_invoice order_invoice_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_invoice
    ADD CONSTRAINT order_invoice_pk PRIMARY KEY (order_invoice_id);


--
-- TOC entry 3302 (class 2606 OID 83888)
-- Name: order_invoice order_invoice_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_invoice
    ADD CONSTRAINT order_invoice_un UNIQUE (code_num);


--
-- TOC entry 3314 (class 2606 OID 84497)
-- Name: order_item_h order_item_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item_h
    ADD CONSTRAINT order_item_h_pk PRIMARY KEY (id);


--
-- TOC entry 3282 (class 2606 OID 67372)
-- Name: order_item order_item_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_pk PRIMARY KEY (order_item_id);


--
-- TOC entry 3276 (class 2606 OID 67352)
-- Name: order order_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_pk PRIMARY KEY (order_id);


--
-- TOC entry 3316 (class 2606 OID 84506)
-- Name: payment_h payment_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.payment_h
    ADD CONSTRAINT payment_h_pk PRIMARY KEY (id);


--
-- TOC entry 3280 (class 2606 OID 67366)
-- Name: payment payment_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.payment
    ADD CONSTRAINT payment_pk PRIMARY KEY (payment_id);


--
-- TOC entry 3318 (class 2606 OID 84515)
-- Name: product_category_h product_category_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product_category_h
    ADD CONSTRAINT product_category_h_pk PRIMARY KEY (id);


--
-- TOC entry 3298 (class 2606 OID 67437)
-- Name: product_category product_category_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product_category
    ADD CONSTRAINT product_category_pk PRIMARY KEY (product_category_id);


--
-- TOC entry 3320 (class 2606 OID 84524)
-- Name: product_h product_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product_h
    ADD CONSTRAINT product_h_pk PRIMARY KEY (id);


--
-- TOC entry 3294 (class 2606 OID 67428)
-- Name: product product_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_pk PRIMARY KEY (product_id);


--
-- TOC entry 3296 (class 2606 OID 67430)
-- Name: product product_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_un UNIQUE (code);


--
-- TOC entry 3322 (class 2606 OID 84533)
-- Name: user_h user_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_h
    ADD CONSTRAINT user_h_pk PRIMARY KEY (id);


--
-- TOC entry 3284 (class 2606 OID 67397)
-- Name: user user_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (user_id);


--
-- TOC entry 3306 (class 2606 OID 84461)
-- Name: user_role_h user_role_h_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_role_h
    ADD CONSTRAINT user_role_h_pk PRIMARY KEY (id);


--
-- TOC entry 3288 (class 2606 OID 67405)
-- Name: user_role user_role_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_role
    ADD CONSTRAINT user_role_pk PRIMARY KEY (user_role_id);


--
-- TOC entry 3290 (class 2606 OID 67407)
-- Name: user_role user_role_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_role
    ADD CONSTRAINT user_role_un UNIQUE (name);


--
-- TOC entry 3286 (class 2606 OID 67490)
-- Name: user user_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_un UNIQUE (email);


--
-- TOC entry 3337 (class 2620 OID 84540)
-- Name: customer_account customer_account_h_history_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER customer_account_h_history_trg AFTER INSERT OR DELETE OR UPDATE ON amain.customer_account FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3332 (class 2620 OID 84541)
-- Name: delivery delivery_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER delivery_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.delivery FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3331 (class 2620 OID 84542)
-- Name: order order_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER order_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain."order" FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3339 (class 2620 OID 84543)
-- Name: order_invoice order_invoice_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER order_invoice_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.order_invoice FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3334 (class 2620 OID 84544)
-- Name: order_item order_item_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER order_item_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.order_item FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3333 (class 2620 OID 84545)
-- Name: payment payment_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER payment_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.payment FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3338 (class 2620 OID 84546)
-- Name: product product_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER product_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.product FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3335 (class 2620 OID 84547)
-- Name: user user_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER user_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain."user" FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3336 (class 2620 OID 84548)
-- Name: user_role user_role_h_trg; Type: TRIGGER; Schema: amain; Owner: postgres
--

CREATE TRIGGER user_role_h_trg AFTER INSERT OR DELETE OR UPDATE ON amain.user_role FOR EACH ROW EXECUTE FUNCTION amain.history_table();


--
-- TOC entry 3329 (class 2606 OID 67472)
-- Name: customer_account customer_account_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.customer_account
    ADD CONSTRAINT customer_account_fk FOREIGN KEY (user_id) REFERENCES amain."user"(user_id);


--
-- TOC entry 3325 (class 2606 OID 75692)
-- Name: order order_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk FOREIGN KEY (payment_id) REFERENCES amain.payment(payment_id) ON DELETE SET NULL;


--
-- TOC entry 3323 (class 2606 OID 67452)
-- Name: order order_fk_1; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk_1 FOREIGN KEY (customer_account_id) REFERENCES amain.customer_account(customer_account_id);


--
-- TOC entry 3324 (class 2606 OID 75687)
-- Name: order order_fk_2; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk_2 FOREIGN KEY (delivery_id) REFERENCES amain.delivery(delivery_id) ON DELETE SET NULL;


--
-- TOC entry 3326 (class 2606 OID 67462)
-- Name: order_item order_item_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_fk FOREIGN KEY (order_id) REFERENCES amain."order"(order_id);


--
-- TOC entry 3327 (class 2606 OID 67467)
-- Name: order_item order_item_fk_1; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_fk_1 FOREIGN KEY (product_id) REFERENCES amain.product(product_id);


--
-- TOC entry 3330 (class 2606 OID 67477)
-- Name: product product_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_fk FOREIGN KEY (product_category_id) REFERENCES amain.product_category(product_category_id);


--
-- TOC entry 3328 (class 2606 OID 67408)
-- Name: user user_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_fk FOREIGN KEY (user_role_id) REFERENCES amain.user_role(user_role_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3524 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA amain; Type: ACL; Schema: -; Owner: postgres
--

GRANT USAGE ON SCHEMA amain TO orderappis_client;
GRANT ALL ON SCHEMA amain TO orderappis_client;


--
-- TOC entry 3525 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE customer_account; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.customer_account TO orderappis_client;


--
-- TOC entry 3526 (class 0 OID 0)
-- Dependencies: 227
-- Name: SEQUENCE customer_account_customer_account_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.customer_account_customer_account_id_seq TO orderappis_client;


--
-- TOC entry 3527 (class 0 OID 0)
-- Dependencies: 231
-- Name: TABLE customer_account_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.customer_account_h TO orderappis_client;


--
-- TOC entry 3528 (class 0 OID 0)
-- Dependencies: 230
-- Name: SEQUENCE customer_account_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.customer_account_h_id_seq TO orderappis_client;


--
-- TOC entry 3531 (class 0 OID 0)
-- Dependencies: 213
-- Name: TABLE delivery; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.delivery TO orderappis_client;


--
-- TOC entry 3532 (class 0 OID 0)
-- Dependencies: 212
-- Name: SEQUENCE delivery_delivery_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.delivery_delivery_id_seq TO orderappis_client;


--
-- TOC entry 3533 (class 0 OID 0)
-- Dependencies: 235
-- Name: TABLE delivery_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.delivery_h TO orderappis_client;


--
-- TOC entry 3534 (class 0 OID 0)
-- Dependencies: 234
-- Name: SEQUENCE delivery_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.delivery_h_id_seq TO orderappis_client;


--
-- TOC entry 3536 (class 0 OID 0)
-- Dependencies: 211
-- Name: TABLE "order"; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain."order" TO orderappis_client;


--
-- TOC entry 3537 (class 0 OID 0)
-- Dependencies: 237
-- Name: TABLE order_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_h TO orderappis_client;


--
-- TOC entry 3538 (class 0 OID 0)
-- Dependencies: 236
-- Name: SEQUENCE order_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_h_id_seq TO orderappis_client;


--
-- TOC entry 3539 (class 0 OID 0)
-- Dependencies: 229
-- Name: TABLE order_invoice; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_invoice TO orderappis_client;


--
-- TOC entry 3540 (class 0 OID 0)
-- Dependencies: 239
-- Name: TABLE order_invoice_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_invoice_h TO orderappis_client;


--
-- TOC entry 3541 (class 0 OID 0)
-- Dependencies: 238
-- Name: SEQUENCE order_invoice_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_invoice_h_id_seq TO orderappis_client;


--
-- TOC entry 3542 (class 0 OID 0)
-- Dependencies: 228
-- Name: SEQUENCE order_invoice_order_invoice_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_invoice_order_invoice_id_seq TO orderappis_client;


--
-- TOC entry 3543 (class 0 OID 0)
-- Dependencies: 217
-- Name: TABLE order_item; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_item TO orderappis_client;


--
-- TOC entry 3544 (class 0 OID 0)
-- Dependencies: 241
-- Name: TABLE order_item_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_item_h TO orderappis_client;


--
-- TOC entry 3545 (class 0 OID 0)
-- Dependencies: 240
-- Name: SEQUENCE order_item_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_item_h_id_seq TO orderappis_client;


--
-- TOC entry 3546 (class 0 OID 0)
-- Dependencies: 216
-- Name: SEQUENCE order_item_order_item_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_item_order_item_id_seq TO orderappis_client;


--
-- TOC entry 3547 (class 0 OID 0)
-- Dependencies: 210
-- Name: SEQUENCE order_order_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.order_order_id_seq TO orderappis_client;


--
-- TOC entry 3551 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE payment; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.payment TO orderappis_client;


--
-- TOC entry 3552 (class 0 OID 0)
-- Dependencies: 243
-- Name: TABLE payment_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.payment_h TO orderappis_client;


--
-- TOC entry 3553 (class 0 OID 0)
-- Dependencies: 242
-- Name: SEQUENCE payment_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.payment_h_id_seq TO orderappis_client;


--
-- TOC entry 3554 (class 0 OID 0)
-- Dependencies: 214
-- Name: SEQUENCE payment_payment_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.payment_payment_id_seq TO orderappis_client;


--
-- TOC entry 3555 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE product; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product TO orderappis_client;


--
-- TOC entry 3556 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE product_category; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product_category TO orderappis_client;


--
-- TOC entry 3557 (class 0 OID 0)
-- Dependencies: 245
-- Name: TABLE product_category_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product_category_h TO orderappis_client;


--
-- TOC entry 3558 (class 0 OID 0)
-- Dependencies: 244
-- Name: SEQUENCE product_category_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.product_category_h_id_seq TO orderappis_client;


--
-- TOC entry 3559 (class 0 OID 0)
-- Dependencies: 226
-- Name: SEQUENCE product_category_product_category_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.product_category_product_category_id_seq TO orderappis_client;


--
-- TOC entry 3560 (class 0 OID 0)
-- Dependencies: 247
-- Name: TABLE product_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product_h TO orderappis_client;


--
-- TOC entry 3561 (class 0 OID 0)
-- Dependencies: 246
-- Name: SEQUENCE product_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.product_h_id_seq TO orderappis_client;


--
-- TOC entry 3562 (class 0 OID 0)
-- Dependencies: 225
-- Name: SEQUENCE product_product_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.product_product_id_seq TO orderappis_client;


--
-- TOC entry 3563 (class 0 OID 0)
-- Dependencies: 219
-- Name: TABLE "user"; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain."user" TO orderappis_client;


--
-- TOC entry 3564 (class 0 OID 0)
-- Dependencies: 249
-- Name: TABLE user_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.user_h TO orderappis_client;


--
-- TOC entry 3565 (class 0 OID 0)
-- Dependencies: 248
-- Name: SEQUENCE user_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.user_h_id_seq TO orderappis_client;


--
-- TOC entry 3566 (class 0 OID 0)
-- Dependencies: 221
-- Name: TABLE user_role; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.user_role TO orderappis_client;


--
-- TOC entry 3567 (class 0 OID 0)
-- Dependencies: 233
-- Name: TABLE user_role_h; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.user_role_h TO orderappis_client;


--
-- TOC entry 3568 (class 0 OID 0)
-- Dependencies: 232
-- Name: SEQUENCE user_role_h_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.user_role_h_id_seq TO orderappis_client;


--
-- TOC entry 3569 (class 0 OID 0)
-- Dependencies: 220
-- Name: SEQUENCE user_role_user_role_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.user_role_user_role_id_seq TO orderappis_client;


--
-- TOC entry 3570 (class 0 OID 0)
-- Dependencies: 218
-- Name: SEQUENCE user_user_id_seq; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON SEQUENCE amain.user_user_id_seq TO orderappis_client;


--
-- TOC entry 2123 (class 826 OID 84539)
-- Name: DEFAULT PRIVILEGES FOR SEQUENCES; Type: DEFAULT ACL; Schema: amain; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA amain GRANT ALL ON SEQUENCES  TO orderappis_client;


--
-- TOC entry 2122 (class 826 OID 84538)
-- Name: DEFAULT PRIVILEGES FOR TABLES; Type: DEFAULT ACL; Schema: amain; Owner: postgres
--

ALTER DEFAULT PRIVILEGES FOR ROLE postgres IN SCHEMA amain GRANT ALL ON TABLES  TO orderappis_client;


-- Completed on 2026-01-11 15:40:42

--
-- PostgreSQL database dump complete
--

