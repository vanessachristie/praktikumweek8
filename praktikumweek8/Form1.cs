using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace praktikumweek8
{
    public partial class FormHasil : Form
    {
        public FormHasil()
        {
            InitializeComponent();
        }
        public static string sqlConnection = "server=localhost; uid=root; pwd=; database=premier_league";
        public MySqlConnection sqlConnect = new MySqlConnection(sqlConnection); // sebagai data koneksi ke dbms nya
        public MySqlCommand sqlCommand;
        public MySqlDataAdapter sqlAdapter;
        public string sqlQuery;

        private void cBoxKiri_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                 DataTable dtTim= new DataTable();
            sqlQuery = "select t.team_name as 'namaTim' , p.player_name , m.manager_name, t.home_stadium, t.capacity from team t, manager m, player p WHERE t.manager_id = m.manager_id and t.captain_id = p.player_id and team_name = '" + cBoxKiri.SelectedValue + "'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTim);
            lJwbKiri1.Text = dtTim.Rows[0][2].ToString();
            lJwbKiri2.Text = dtTim.Rows[0][1].ToString();
            lBawah1.Text = dtTim.Rows[0]["home_stadium"].ToString();
            lBawah2.Text = dtTim.Rows[0]["capacity"].ToString();
            }
            catch (Exception)
            {

                
            }
          
            


        }

        private void FormHasil_Load(object sender, EventArgs e)
        {
            sqlConnect.Open();
            DataTable dtTim = new DataTable();
            DataTable dtTim2 = new DataTable();
            sqlQuery = "select t.team_name as 'namaTim' , p.player_name , m.manager_name from team t,manager m, player p WHERE t.manager_id = m.manager_id and t.captain_id = p.player_id ";
            sqlCommand = new MySqlCommand(sqlQuery,sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTim);
            sqlQuery = "select t.team_name as 'namaTim' , p.player_name , m.manager_name from team t,manager m, player p WHERE t.manager_id = m.manager_id and t.captain_id = p.player_id ";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTim2);
            cBoxKiri.DataSource = dtTim;
            cBoxKiri.DisplayMember = "namaTim";
            cBoxKiri.ValueMember = "namaTim";
            cBoxKanan.DataSource = dtTim2;
            cBoxKanan.DisplayMember = "namaTim";
            cBoxKanan.ValueMember = "namaTim";



        }

        private void cBoxKanan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dtTim= new DataTable();
                sqlQuery = "select t.team_name as 'namaTim' , p.player_name , m.manager_name from team t, manager m, player p WHERE t.manager_id = m.manager_id and t.captain_id = p.player_id and team_name = '" + cBoxKanan.SelectedValue + "'";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTim);
                lJwbKanan1.Text = dtTim.Rows[0][2].ToString();
                lJwbKanan2.Text = dtTim.Rows[0][1].ToString();
            }
            catch (Exception)
            {


            }
        }
    }
}
