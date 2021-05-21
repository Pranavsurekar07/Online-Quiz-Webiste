using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestDemo
{
    public partial class AddQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    BindData();
                    if (!string.IsNullOrWhiteSpace(Request.QueryString["QuestionID"]))
                    {
                        string id = Request.QueryString["QuestionID"].ToString();
                        List<Tuple<string, string>> parametersList = new List<Tuple<string, string>>();
                        parametersList.Add(new Tuple<string, string>("@Id", id));
                        var data = SqlDataBind.GetDataByStoredProcedure("usp_GetQuestionById", "ConnectionString", parametersList);//Get Question in textboxes to update
                        if (data.Tables[0].Rows.Count > 0)
                        {
                            txtQuestion.Text = data.Tables[0].Rows[0]["Question"].ToString();
                            txtOption1.Text = data.Tables[0].Rows[0]["Option1"].ToString();
                            txtOption2.Text = data.Tables[0].Rows[0]["Option2"].ToString();
                            txtOption3.Text = data.Tables[0].Rows[0]["Option3"].ToString();
                            txtOption4.Text = data.Tables[0].Rows[0]["Option4"].ToString();
                            string answer = data.Tables[0].Rows[0]["Answer"].ToString();
                            if (answer == "1")
                                rboption1.Checked = true;
                            else if (answer == "2")
                                rboption2.Checked = true;
                            else if (answer == "3")
                                rboption3.Checked = true;
                            else
                                rboption4.Checked = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string value;
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("usp_GetCountOfQuestion", sqlConnection);//get count of question
            cmd.CommandType = CommandType.StoredProcedure;
            int count = (Int32)cmd.ExecuteScalar();
            if (count == 10)//check count is less than or equal because not to allow more than 10 questions to add
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('Only 10 questions allowed');", true);

            }
            else
            {
                if (rboption1.Checked)
                    value = "1";
                else if (rboption2.Checked)
                    value = "2";
                else if (rboption3.Checked)
                    value = "3";
                else
                    value = "4";
                int id = 0;
                List<Tuple<string, string>> parametersList = new List<Tuple<string, string>>();
                if (!string.IsNullOrWhiteSpace(Request.QueryString["QuestionID"]))
                    id = Convert.ToInt32(Request.QueryString["QuestionID"]);
                parametersList.Add(new Tuple<string, string>("@Id", id.ToString()));
                parametersList.Add(new Tuple<string, string>("@question", txtQuestion.Text.Trim()));
                parametersList.Add(new Tuple<string, string>("@option1", txtOption1.Text.Trim()));
                parametersList.Add(new Tuple<string, string>("@option2", txtOption2.Text.Trim()));
                parametersList.Add(new Tuple<string, string>("@option3", txtOption3.Text.Trim()));
                parametersList.Add(new Tuple<string, string>("@option4", txtOption4.Text.Trim()));
                parametersList.Add(new Tuple<string, string>("@answer", value.Trim()));
                var data = SqlDataBind.SaveDataByStoredProcedure("usp_InsertQuestion", "ConnectionString", parametersList);
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('Data saved successfully');", true);
                Clear();
                BindData();
            }

        }
        //Delete question by its ID
        protected void gvBlog_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int QuestionID = (int)e.Keys["QuestionID"];
            List<Tuple<string, string>> parameterList = new List<Tuple<string, string>>();
            parameterList.Add(new Tuple<string, string>("@Id", QuestionID.ToString()));
            var data = SqlDataBind.SaveDataByStoredProcedure("usp_DeleteQuestionById", "ConnectionString", parameterList);
            if (data > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "success", "alert('Data Deleted successfully');", true);
            }
            BindData();
        }
        void BindData()//Get all questions in grid view 
        {
            var data = SqlDataBind.GetDataByStoredProcedure("usp_GetAllQuestions", "ConnectionString");
            if (data.Tables[0].Rows.Count > 0)
            {
                gvBlog.DataSource = data.Tables[0];
                gvBlog.DataBind();
            }
        }
        void Clear()//used when need to clear fields on button click
        {
            txtQuestion.Text = "";
            txtOption1.Text = "";
            txtOption2.Text = "";
            txtOption3.Text = "";
            txtOption4.Text = "";
            rboption1.Checked = false;
            rboption2.Checked = false;
            rboption3.Checked = false;
            rboption4.Checked = false;
        }
    }
}