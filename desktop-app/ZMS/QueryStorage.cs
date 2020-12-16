﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZMS
{
  public class QueryStorage
  {
    //Get count data
    public string query_countOrderCategoryCode = "SELECT COUNT(*) FROM `tb_orders` o INNER JOIN tb_pricelist p on o.category_id = p.category_id "; 
    public string query_countOrderCategoryCode_ART = "Select COUNT(*) FROM tb_orders WHERE type_abr = 'Article'";

    //Table data - Get all data
    public string query_getAllCurrenciesList = "SELECT * FROM tb_currency";
    public string query_getAllClientsList = "SELECT * FROM tb_client";
    public string query_getAllAssigneeList = "SELECT * FROM tb_assignee";
    public string query_getAllCategoryList = "SELECT * FROM tb_pricelist";

    //Clients - Client list
    public string query_getClientList = "SELECT client_id AS 'Client ID', client_name AS 'Client', industry AS 'Industry', client_addressCountry AS 'Country' ,clientRep_name AS 'Client Rep', clientRep_contactEmail AS 'Email Contact' FROM tb_client";

    //Orders - create
    public string query_CreateNewOrder = "INSERT INTO tb_orders VALUES (@order_id,@title,@description,@scheduled_date,@deadline_date,@editor_url,@status,@is_complete,@is_invoiced,@is_closed,@category_id,@client_id,@invoice_id,@is_inprogress,@currency_id,@order_cost,@order_size,@order_dateCreated,@date_orderCompleted,@assignee_id,@created_by)";

    //Orders - State selection
    public string query_getInprogressOrderList = "SELECT o.order_id AS 'Order ID', o.title AS 'Title', x.category_description AS 'Category', c.client_name AS 'Client', o.deadline_date AS 'Deadline', o.status AS 'Status' , m.currency_code AS 'Currency', o.order_cost AS 'Value' , a.assignee_name AS 'Assignee' FROM tb_orders o INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_client c on o.client_id = c.client_id INNER JOIN tb_currency m on o.currency_id = m.currency_id INNER JOIN tb_assignee a on o.assignee_id = a.assignee_id WHERE o.is_inprogress = 1 AND o.is_complete = 0";
    public string query_getOrdersCompletedAndPendingInvoiceList = "SELECT o.order_id AS 'Order ID', o.title AS 'Title', x.category_description AS 'Category', c.client_name AS 'Client', o.date_orderCompleted AS 'Date Completed', o.status AS 'Status' , m.currency_code AS 'Currency', o.order_cost AS 'Value' , a.assignee_name AS 'Assignee' FROM tb_orders o INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_client c on o.client_id = c.client_id INNER JOIN tb_currency m on o.currency_id = m.currency_id INNER JOIN tb_assignee a on o.assignee_id = a.assignee_id WHERE o.is_inprogress = 0 AND o.is_invoiced = 0 AND o.is_complete = 1";
    public string query_getOrdersInvoicedAndPendingPayment = "SELECT o.order_id AS 'Order ID', o.title AS 'Title', x.category_description AS 'Category', c.client_name AS 'Client', o.date_orderCompleted AS 'Date Completed', o.status AS 'Status' , m.currency_code AS 'Currency', o.order_cost AS 'Value' , a.assignee_name AS 'Assignee' FROM tb_orders o INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_client c on o.client_id = c.client_id INNER JOIN tb_currency m on o.currency_id = m.currency_id INNER JOIN tb_assignee a on o.assignee_id = a.assignee_id WHERE o.is_invoiced = 1 AND o.is_complete = 1 AND o.is_closed = 0";
    public string query_getOrdersPaidAndClosedList = "SELECT o.order_id AS 'Order ID', o.title AS 'Title', x.category_description AS 'Category', c.client_name AS 'Client', o.date_orderCompleted AS 'Date Completed', o.status AS 'Status' , m.currency_code AS 'Currency', o.order_cost AS 'Value' , a.assignee_name AS 'Assignee' FROM tb_orders o INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_client c on o.client_id = c.client_id INNER JOIN tb_currency m on o.currency_id = m.currency_id INNER JOIN tb_assignee a on o.assignee_id = a.assignee_id WHERE o.is_invoiced = 1 AND o.is_complete = 1 AND o.is_closed = 1";
    public string query_getAllOrdersSearchbar = "SELECT o.order_id AS 'Order ID', o.title AS 'Title', x.category_description AS 'Category', c.client_name AS 'Client', o.deadline_date AS 'Deadline', o.status AS 'Status' , m.currency_id AS 'Currency', o.order_cost AS 'Value' , a.assignee_id AS 'Assignee' FROM tb_orders o INNER JOIN tb_assignee a on o.assignee_id = a.assignee_id INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_client c on o.client_id = c.client_id INNER JOIN tb_currency m on o.currency_id = m.currency_id";

    //Invoices
    public string query_getPaymentPendingOrderList = "SELECT i.invoice_id AS 'Invoice ID', o.order_id AS 'Order ID',i.invoice_paymentReference AS 'Reference', o.title AS 'Title', o.status AS 'Status', x.category_description AS 'Category', c.client_name AS 'client' , m.currency_id AS 'Currency', o.order_cost AS 'Order Value', o.date_orderCompleted AS 'Order Completed', i.invoice_date AS 'Invoiced Date', a.assignee_name AS 'Assignee' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_assignee a on i.assignee_id = a.assignee_id INNER JOIN tb_orders o on o.invoice_id = i.invoice_id INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_currency m on o.currency_id = m.currency_id WHERE i.invoice_sent = 1 AND i.invoice_paid = 0";
    public string query_getPaymentPendingInvoiceList = "SELECT i.invoice_id AS 'Invoice ID', i.invoice_paymentReference AS 'Reference', c.client_name AS 'Client', i.invoice_orderCount AS 'Order Items', i.currency_id AS 'Currency', i.invoice_totalCurrency AS 'Amount' , i.invoice_totalRands AS 'R. Conversion', i.invoice_date AS 'Date Created' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_currency m on i.currency_id = m.currency_id WHERE i.invoice_sent = 1 AND i.invoice_paid = 0";
    public string query_getPaymentReceivedAndClosedOrderList = "SELECT i.invoice_id AS 'Invoice ID', o.order_id AS 'Order ID',i.invoice_paymentReference AS 'Reference', o.title AS 'Title', o.status AS 'Status', x.category_description AS 'Category', c.client_name AS 'client' , m.currency_id AS 'Currency', o.order_cost AS 'Order Value', o.date_orderCompleted AS 'Order Completed', i.invoice_date AS 'Invoiced Date', a.assignee_name AS 'Assignee' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_assignee a on i.assignee_id = a.assignee_id INNER JOIN tb_orders o on o.invoice_id = i.invoice_id INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_currency m on o.currency_id = m.currency_id WHERE i.invoice_sent = 1 AND i.invoice_paid = 1";
    public string query_getPaymentReceivedAndClosedInvoiceList = "SELECT i.invoice_id AS 'Invoice ID', i.invoice_paymentReference AS 'Reference', c.client_name AS 'Client', i.invoice_orderCount AS 'Order Items', i.currency_id AS 'Currency', i.invoice_totalCurrency AS 'Amount' , i.invoice_totalRands AS 'R. Conversion', i.invoice_date AS 'Date Created' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_currency m on i.currency_id = m.currency_id WHERE i.invoice_sent = 1 AND i.invoice_paid = 1";
    public string query_getAllOrdersInInvoicesSearchbar = "SELECT i.invoice_id AS 'Invoice ID', o.order_id AS 'Order ID',i.invoice_paymentReference AS 'Reference', o.title AS 'Title', o.status AS 'Status', x.category_description AS 'Category', c.client_name AS 'client' , m.currency_id AS 'Currency', o.order_cost AS 'Order Value', o.date_orderCompleted AS 'Order Completed', i.invoice_date AS 'Invoiced Date', a.assignee_name AS 'Assignee' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_assignee a on i.assignee_id = a.assignee_id INNER JOIN tb_orders o on i.invoice_id = o.invoice_id INNER JOIN tb_pricelist x on o.category_id = x.category_id INNER JOIN tb_currency m on i.currency_id = m.currency_id";
    public string query_getAllInvoicesSearchbar = "SELECT i.invoice_id AS 'Invoice ID', i.invoice_paymentReference AS 'Reference', c.client_name AS 'Client', i.invoice_orderCount AS 'Order Items', m.currency_code AS 'Currency', i.invoice_totalCurrency AS 'Amount' , i.invoice_totalRands AS 'R. Conversion', i.invoice_date AS 'Date Created' FROM tb_invoices i INNER JOIN tb_client c on i.client_id = c.client_id INNER JOIN tb_currency m on i.currency_id = m.currency_id";


    //Other
    //public string query_buildExcelExportOrderList = "SELECT order_id AS 'Order ID', title AS 'Title', type_category AS 'Category', client_name AS 'Client',  status AS 'Status' , date_orderCompleted AS 'Date Completed', currency_id AS 'Currency', order_cost AS 'Value' , order_assignee AS 'Assignee'  FROM tb_orders WHERE is_complete = 1 ";
    
    //public string query_getSelectedClientPendingInvoiceList = "SELECT order_id AS 'Order ID', title AS 'Title', client_name AS 'Client', status AS 'Status', currency_id AS 'Currency', order_cost AS 'Value'  FROM tb_orders WHERE is_invoiced = 0 AND is_complete = 1 AND client_name = ";
  }
}