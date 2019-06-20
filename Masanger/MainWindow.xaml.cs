﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Masanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string strCon = ConfigurationManager.ConnectionStrings["SomeeConnection"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(strCon))
            {
                sqlConnection.Open();
                string sqlQuery = "Select Id, MessageStatusId, SenderId, DateSend, Text From tblMessages";
                SqlCommand com = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader["Id"].ToString();
                    var status = reader["MessageStatusId"].ToString();
                    var sender = reader["SenderId"].ToString();
                    var dateSend = reader["DateSend"].ToString();
                    var text = reader["Text"].ToString();

                    textBox.Text = $"{id} - {status} - {sender} - {text} - {dateSend}\n";
                }
            }
        }
    }
}