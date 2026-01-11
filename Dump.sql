----------------------------------------------------------------
-- SPUSTIT PŘÍKAZEM: psql -U postgres -d orderappis -f Dump.sql
----------------------------------------------------------------
--
-- PostgreSQL database dump
--

-- Dumped from database version 14.9
-- Dumped by pg_dump version 14.9

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
-- TOC entry 3413 (class 0 OID 0)
-- Dependencies: 213
-- Name: COLUMN delivery.delivery_type; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.delivery.delivery_type IS '1 = express, 2 = 24h, 3 = basic';


--
-- TOC entry 3414 (class 0 OID 0)
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
    updated_at timestamp without time zone NOT NULL
);


ALTER TABLE amain."order" OWNER TO postgres;

--
-- TOC entry 3416 (class 0 OID 0)
-- Dependencies: 211
-- Name: COLUMN "order".status; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain."order".status IS 'vytvořena (1), zpracovává se (2), připravena k odeslání (3), doručuje se (4), dokončena(5), zrušena(6)';


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
-- TOC entry 3420 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.payment_method; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.payment_method IS '0=hotově, 1=kartou, 2=dobírka';


--
-- TOC entry 3421 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.total_czk; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.total_czk IS '0 = zaplaceno vše (spárováno s objednávkou)';


--
-- TOC entry 3422 (class 0 OID 0)
-- Dependencies: 215
-- Name: COLUMN payment.status; Type: COMMENT; Schema: amain; Owner: postgres
--

COMMENT ON COLUMN amain.payment.status IS '1 = platná, 0 = storno';


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
-- TOC entry 221 (class 1259 OID 67401)
-- Name: user_role; Type: TABLE; Schema: amain; Owner: postgres
--

CREATE TABLE amain.user_role (
    user_role_id integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE amain.user_role OWNER TO postgres;

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
-- TOC entry 3398 (class 0 OID 67413)
-- Dependencies: 222
-- Data for Name: customer_account; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.customer_account (customer_account_id, user_id, created_at, valid_to) FROM stdin;
1	1	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
2	2	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
3	3	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
4	4	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
5	5	2025-11-15 15:46:27.044284	2028-11-15 15:46:27.044284
\.


--
-- TOC entry 3389 (class 0 OID 67356)
-- Dependencies: 213
-- Data for Name: delivery; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.delivery (delivery_id, delivery_type, delivery_date, delivery_address, status, price_czk, note) FROM stdin;
\.


--
-- TOC entry 3387 (class 0 OID 67348)
-- Dependencies: 211
-- Data for Name: order; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain."order" (order_id, payment_id, customer_account_id, delivery_id, total_price_czk, status, ordered_at, updated_at) FROM stdin;
19	\N	2	\N	0.00	1	2025-09-23 19:01:03.137	2025-11-23 19:01:03.137185
20	\N	2	\N	0.00	1	2025-09-23 19:01:03.137	2025-11-23 19:01:03.137185
21	\N	1	\N	0.00	1	2025-09-23 19:01:03.137	2025-11-23 19:01:03.137185
22	\N	2	\N	0.00	1	2025-09-23 19:01:03.137	2025-11-23 19:01:03.137185
24	\N	4	\N	0.00	1	2025-08-23 19:01:03.137	2025-11-23 19:01:03.137185
25	\N	5	\N	0.00	1	2025-08-23 19:01:03.137	2025-11-23 19:01:03.137185
26	\N	5	\N	0.00	1	2025-08-23 19:01:03.137	2025-11-23 19:01:03.137185
23	\N	3	\N	0.00	1	2025-10-23 19:01:03.137	2025-11-23 19:01:03.137185
27	\N	5	\N	0.00	1	2025-07-23 19:01:03.137	2025-11-23 19:01:03.137185
12	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
13	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
14	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
15	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
16	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
17	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
18	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
28	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
29	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
30	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
31	\N	1	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
32	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
33	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
34	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
35	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
36	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
37	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
38	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
39	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
40	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
41	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
42	\N	1	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
43	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
44	\N	3	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
45	\N	4	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
46	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
47	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
48	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
49	\N	5	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
50	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
51	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
52	\N	2	\N	0.00	1	2025-11-23 19:01:03.137185	2025-11-23 19:01:03.137185
11	\N	1	\N	10000.00	1	2025-11-23 19:01:03.137185	2025-12-28 10:47:21.610374
\.


--
-- TOC entry 3405 (class 0 OID 83870)
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
-- TOC entry 3393 (class 0 OID 67368)
-- Dependencies: 217
-- Data for Name: order_item; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.order_item (order_item_id, order_id, product_id, qty, note) FROM stdin;
60	11	21	10	\N
61	11	23	5	testovací data
\.


--
-- TOC entry 3391 (class 0 OID 67362)
-- Dependencies: 215
-- Data for Name: payment; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain.payment (payment_id, payment_date, payment_method, total_czk, status, note) FROM stdin;
\.


--
-- TOC entry 3399 (class 0 OID 67422)
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
-- TOC entry 3400 (class 0 OID 67431)
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
-- TOC entry 3395 (class 0 OID 67393)
-- Dependencies: 219
-- Data for Name: user; Type: TABLE DATA; Schema: amain; Owner: postgres
--

COPY amain."user" (user_id, user_role_id, login, password, firstname, lastname, email, company_name, phone_num1, phone_num2) FROM stdin;
2	1	z00002	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Petr	Vomáčka	petr.vomacka@email.com	Firma2	777888701	\N
3	1	z00003	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Eva	Dvořáková	eva.dvorakova@email.com	Firma3	777888702	\N
4	1	z00004	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Karel	Krejčí	karel.krejci@email.com	Firma4	777888703	\N
5	1	z00005	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Lucie	Procházková	lucie.prochazkova@email.com	Firma5	777888704	\N
6	3	s00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Martin	Hrubý	martin.hruby@email.com	Sklad1	777888705	\N
7	3	s00002	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Petra	Mařeková	petra.marekova@email.com	Sklad2	777888706	\N
8	3	s00003	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Roman	Kovář	roman.kovar@email.com	Sklad3	777888707	\N
10	4	a00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Admin	Super	admin@email.com	FirmaAdmin	777888709	\N
1	1	z00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Jan	Novák	jan.novak@email.com	Firma1	777888700	\N
9	2	m00001	$2a$11$o8Q7UG5R.jlO5mJpMvd.auCDtKGsK8uaaRQ7NMnzZpUHKZtIEqb0S	Jiří	Bole	jiri.bole@email.com	FirmaManager	777888708	\N
\.


--
-- TOC entry 3397 (class 0 OID 67401)
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
-- TOC entry 3428 (class 0 OID 0)
-- Dependencies: 227
-- Name: customer_account_customer_account_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.customer_account_customer_account_id_seq', 6, true);


--
-- TOC entry 3429 (class 0 OID 0)
-- Dependencies: 212
-- Name: delivery_delivery_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.delivery_delivery_id_seq', 13, true);


--
-- TOC entry 3430 (class 0 OID 0)
-- Dependencies: 228
-- Name: order_invoice_order_invoice_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_invoice_order_invoice_id_seq', 7, true);


--
-- TOC entry 3431 (class 0 OID 0)
-- Dependencies: 216
-- Name: order_item_order_item_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_item_order_item_id_seq', 61, true);


--
-- TOC entry 3432 (class 0 OID 0)
-- Dependencies: 210
-- Name: order_order_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.order_order_id_seq', 63, true);


--
-- TOC entry 3433 (class 0 OID 0)
-- Dependencies: 214
-- Name: payment_payment_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.payment_payment_id_seq', 3, true);


--
-- TOC entry 3434 (class 0 OID 0)
-- Dependencies: 226
-- Name: product_category_product_category_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_category_product_category_id_seq', 1, false);


--
-- TOC entry 3435 (class 0 OID 0)
-- Dependencies: 225
-- Name: product_product_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.product_product_id_seq', 30, true);


--
-- TOC entry 3436 (class 0 OID 0)
-- Dependencies: 220
-- Name: user_role_user_role_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_role_user_role_id_seq', 4, true);


--
-- TOC entry 3437 (class 0 OID 0)
-- Dependencies: 218
-- Name: user_user_id_seq; Type: SEQUENCE SET; Schema: amain; Owner: postgres
--

SELECT pg_catalog.setval('amain.user_user_id_seq', 15, true);


--
-- TOC entry 3228 (class 2606 OID 67417)
-- Name: customer_account customer_account_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.customer_account
    ADD CONSTRAINT customer_account_pk PRIMARY KEY (customer_account_id);


--
-- TOC entry 3214 (class 2606 OID 67360)
-- Name: delivery delivery_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.delivery
    ADD CONSTRAINT delivery_pk PRIMARY KEY (delivery_id);


--
-- TOC entry 3236 (class 2606 OID 83886)
-- Name: order_invoice order_invoice_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_invoice
    ADD CONSTRAINT order_invoice_pk PRIMARY KEY (order_invoice_id);


--
-- TOC entry 3238 (class 2606 OID 83888)
-- Name: order_invoice order_invoice_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_invoice
    ADD CONSTRAINT order_invoice_un UNIQUE (code_num);


--
-- TOC entry 3218 (class 2606 OID 67372)
-- Name: order_item order_item_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_pk PRIMARY KEY (order_item_id);


--
-- TOC entry 3212 (class 2606 OID 67352)
-- Name: order order_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_pk PRIMARY KEY (order_id);


--
-- TOC entry 3216 (class 2606 OID 67366)
-- Name: payment payment_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.payment
    ADD CONSTRAINT payment_pk PRIMARY KEY (payment_id);


--
-- TOC entry 3234 (class 2606 OID 67437)
-- Name: product_category product_category_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product_category
    ADD CONSTRAINT product_category_pk PRIMARY KEY (product_category_id);


--
-- TOC entry 3230 (class 2606 OID 67428)
-- Name: product product_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_pk PRIMARY KEY (product_id);


--
-- TOC entry 3232 (class 2606 OID 67430)
-- Name: product product_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_un UNIQUE (code);


--
-- TOC entry 3220 (class 2606 OID 67397)
-- Name: user user_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_pk PRIMARY KEY (user_id);


--
-- TOC entry 3224 (class 2606 OID 67405)
-- Name: user_role user_role_pk; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_role
    ADD CONSTRAINT user_role_pk PRIMARY KEY (user_role_id);


--
-- TOC entry 3226 (class 2606 OID 67407)
-- Name: user_role user_role_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.user_role
    ADD CONSTRAINT user_role_un UNIQUE (name);


--
-- TOC entry 3222 (class 2606 OID 67490)
-- Name: user user_un; Type: CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_un UNIQUE (email);


--
-- TOC entry 3245 (class 2606 OID 67472)
-- Name: customer_account customer_account_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.customer_account
    ADD CONSTRAINT customer_account_fk FOREIGN KEY (user_id) REFERENCES amain."user"(user_id);


--
-- TOC entry 3241 (class 2606 OID 75692)
-- Name: order order_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk FOREIGN KEY (payment_id) REFERENCES amain.payment(payment_id) ON DELETE SET NULL;


--
-- TOC entry 3239 (class 2606 OID 67452)
-- Name: order order_fk_1; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk_1 FOREIGN KEY (customer_account_id) REFERENCES amain.customer_account(customer_account_id);


--
-- TOC entry 3240 (class 2606 OID 75687)
-- Name: order order_fk_2; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."order"
    ADD CONSTRAINT order_fk_2 FOREIGN KEY (delivery_id) REFERENCES amain.delivery(delivery_id) ON DELETE SET NULL;


--
-- TOC entry 3242 (class 2606 OID 67462)
-- Name: order_item order_item_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_fk FOREIGN KEY (order_id) REFERENCES amain."order"(order_id);


--
-- TOC entry 3243 (class 2606 OID 67467)
-- Name: order_item order_item_fk_1; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.order_item
    ADD CONSTRAINT order_item_fk_1 FOREIGN KEY (product_id) REFERENCES amain.product(product_id);


--
-- TOC entry 3246 (class 2606 OID 67477)
-- Name: product product_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain.product
    ADD CONSTRAINT product_fk FOREIGN KEY (product_category_id) REFERENCES amain.product_category(product_category_id);


--
-- TOC entry 3244 (class 2606 OID 67408)
-- Name: user user_fk; Type: FK CONSTRAINT; Schema: amain; Owner: postgres
--

ALTER TABLE ONLY amain."user"
    ADD CONSTRAINT user_fk FOREIGN KEY (user_role_id) REFERENCES amain.user_role(user_role_id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 3411 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA amain; Type: ACL; Schema: -; Owner: postgres
--

GRANT USAGE ON SCHEMA amain TO orderappis_client;
GRANT ALL ON SCHEMA amain TO orderappis_client;


--
-- TOC entry 3412 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE customer_account; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.customer_account TO orderappis_client;


--
-- TOC entry 3415 (class 0 OID 0)
-- Dependencies: 213
-- Name: TABLE delivery; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.delivery TO orderappis_client;


--
-- TOC entry 3417 (class 0 OID 0)
-- Dependencies: 211
-- Name: TABLE "order"; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain."order" TO orderappis_client;


--
-- TOC entry 3418 (class 0 OID 0)
-- Dependencies: 229
-- Name: TABLE order_invoice; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_invoice TO orderappis_client;


--
-- TOC entry 3419 (class 0 OID 0)
-- Dependencies: 217
-- Name: TABLE order_item; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.order_item TO orderappis_client;


--
-- TOC entry 3423 (class 0 OID 0)
-- Dependencies: 215
-- Name: TABLE payment; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.payment TO orderappis_client;


--
-- TOC entry 3424 (class 0 OID 0)
-- Dependencies: 223
-- Name: TABLE product; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product TO orderappis_client;


--
-- TOC entry 3425 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE product_category; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.product_category TO orderappis_client;


--
-- TOC entry 3426 (class 0 OID 0)
-- Dependencies: 219
-- Name: TABLE "user"; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain."user" TO orderappis_client;


--
-- TOC entry 3427 (class 0 OID 0)
-- Dependencies: 221
-- Name: TABLE user_role; Type: ACL; Schema: amain; Owner: postgres
--

GRANT ALL ON TABLE amain.user_role TO orderappis_client;


--
-- PostgreSQL database dump complete
--

