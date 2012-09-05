using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dcms.Orm;
using System.Data.SqlClient;

public class SqlDb
{
	public class Dcms_Admin:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Admin_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Admin";
		}

		private System.Int32 _Admin_Id;
		public System.Int32 Admin_Id
		{
			get{ return _Admin_Id; }
			set{ _Admin_Id = value; }
		}
		private System.String _Admin_Name;
		public System.String Admin_Name
		{
			get{ return _Admin_Name; }
			set{ _Admin_Name = value; }
		}
		private System.String _Admin_Pwd;
		public System.String Admin_Pwd
		{
			get{ return _Admin_Pwd; }
			set{ _Admin_Pwd = value; }
		}
		private System.Int32 _Admin_LoginTimes;
		public System.Int32 Admin_LoginTimes
		{
			get{ return _Admin_LoginTimes; }
			set{ _Admin_LoginTimes = value; }
		}
		private System.String _Admin_LastIp;
		public System.String Admin_LastIp
		{
			get{ return _Admin_LastIp; }
			set{ _Admin_LastIp = value; }
		}
		private System.DateTime _Admin_LastTime;
		public System.DateTime Admin_LastTime
		{
			get{ return _Admin_LastTime; }
			set{ _Admin_LastTime = value; }
		}
		private System.String _Admin_Email;
		public System.String Admin_Email
		{
			get{ return _Admin_Email; }
			set{ _Admin_Email = value; }
		}
		private System.Int32 _Admin_RoleId;
		public System.Int32 Admin_RoleId
		{
			get{ return _Admin_RoleId; }
			set{ _Admin_RoleId = value; }
		}
		private System.DateTime _Admin_AddTime;
		public System.DateTime Admin_AddTime
		{
			get{ return _Admin_AddTime; }
			set{ _Admin_AddTime = value; }
		}


		public static Exp _ADMIN_ID_ = new Exp("Admin_Id");
		public static Exp _ADMIN_NAME_ = new Exp("Admin_Name");
		public static Exp _ADMIN_PWD_ = new Exp("Admin_Pwd");
		public static Exp _ADMIN_LOGINTIMES_ = new Exp("Admin_LoginTimes");
		public static Exp _ADMIN_LASTIP_ = new Exp("Admin_LastIp");
		public static Exp _ADMIN_LASTTIME_ = new Exp("Admin_LastTime");
		public static Exp _ADMIN_EMAIL_ = new Exp("Admin_Email");
		public static Exp _ADMIN_ROLEID_ = new Exp("Admin_RoleId");
		public static Exp _ADMIN_ADDTIME_ = new Exp("Admin_AddTime");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Admin_Id",SqlDbType.Int);
			p.Value = _Admin_Id;
			rs.Add(p);
			if (_Admin_Name != null)
			{
				p = new SqlParameter("@Admin_Name",SqlDbType.NVarChar);
				p.Value = _Admin_Name;
				rs.Add(p);
			}
			if (_Admin_Pwd != null)
			{
				p = new SqlParameter("@Admin_Pwd",SqlDbType.NVarChar);
				p.Value = _Admin_Pwd;
				rs.Add(p);
			}
			p = new SqlParameter("@Admin_LoginTimes",SqlDbType.Int);
			p.Value = _Admin_LoginTimes;
			rs.Add(p);
			if (_Admin_LastIp != null)
			{
				p = new SqlParameter("@Admin_LastIp",SqlDbType.NVarChar);
				p.Value = _Admin_LastIp;
				rs.Add(p);
			}
			if (_Admin_LastTime != null)
			{
				if (_Admin_LastTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Admin_LastTime",SqlDbType.SmallDateTime);
					p.Value = _Admin_LastTime;
					rs.Add(p);
				}
			}
			if (_Admin_Email != null)
			{
				p = new SqlParameter("@Admin_Email",SqlDbType.NText);
				p.Value = _Admin_Email;
				rs.Add(p);
			}
			p = new SqlParameter("@Admin_RoleId",SqlDbType.Int);
			p.Value = _Admin_RoleId;
			rs.Add(p);
			if (_Admin_AddTime != null)
			{
				if (_Admin_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Admin_AddTime",SqlDbType.SmallDateTime);
					p.Value = _Admin_AddTime;
					rs.Add(p);
				}
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_Id")))
			{
				_Admin_Id = (System.Int32)Rd["Admin_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_Name")))
			{
				_Admin_Name = (System.String)Rd["Admin_Name"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_Pwd")))
			{
				_Admin_Pwd = (System.String)Rd["Admin_Pwd"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_LoginTimes")))
			{
				_Admin_LoginTimes = (System.Int32)Rd["Admin_LoginTimes"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_LastIp")))
			{
				_Admin_LastIp = (System.String)Rd["Admin_LastIp"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_LastTime")))
			{
				_Admin_LastTime = (System.DateTime)Rd["Admin_LastTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_Email")))
			{
				_Admin_Email = (System.String)Rd["Admin_Email"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_RoleId")))
			{
				_Admin_RoleId = (System.Int32)Rd["Admin_RoleId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Admin_AddTime")))
			{
				_Admin_AddTime = (System.DateTime)Rd["Admin_AddTime"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Admin();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Admin([Admin_Name],[Admin_Pwd],[Admin_LoginTimes],[Admin_LastIp],[Admin_LastTime],[Admin_Email],[Admin_RoleId],[Admin_AddTime]) VALUES (@Admin_Name ,@Admin_Pwd ,@Admin_LoginTimes ,@Admin_LastIp ,@Admin_LastTime ,@Admin_Email ,@Admin_RoleId ,@Admin_AddTime )";
		}


	}

	public class Dcms_BaseInfo:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "BaseInfo_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_BaseInfo";
		}

		private System.Int32 _BaseInfo_Id;
		public System.Int32 BaseInfo_Id
		{
			get{ return _BaseInfo_Id; }
			set{ _BaseInfo_Id = value; }
		}
		private System.Int32 _BaseInfo_CateId;
		public System.Int32 BaseInfo_CateId
		{
			get{ return _BaseInfo_CateId; }
			set{ _BaseInfo_CateId = value; }
		}
		private System.String _BaseInfo_CateName;
		public System.String BaseInfo_CateName
		{
			get{ return _BaseInfo_CateName; }
			set{ _BaseInfo_CateName = value; }
		}
		private System.String _BaseInfo_Title;
		public System.String BaseInfo_Title
		{
			get{ return _BaseInfo_Title; }
			set{ _BaseInfo_Title = value; }
		}
		private System.String _BaseInfo_State;
		public System.String BaseInfo_State
		{
			get{ return _BaseInfo_State; }
			set{ _BaseInfo_State = value; }
		}
		private System.String _BaseInfo_Image;
		public System.String BaseInfo_Image
		{
			get{ return _BaseInfo_Image; }
			set{ _BaseInfo_Image = value; }
		}
		private System.String _BaseInfo_Content;
		public System.String BaseInfo_Content
		{
			get{ return _BaseInfo_Content; }
			set{ _BaseInfo_Content = value; }
		}
		private System.Int32 _BaseInfo_Order;
		public System.Int32 BaseInfo_Order
		{
			get{ return _BaseInfo_Order; }
			set{ _BaseInfo_Order = value; }
		}
		private System.DateTime _BaseInfo_AddTime;
		public System.DateTime BaseInfo_AddTime
		{
			get{ return _BaseInfo_AddTime; }
			set{ _BaseInfo_AddTime = value; }
		}
		private System.String _BaseInfo_SEOTitle;
		public System.String BaseInfo_SEOTitle
		{
			get{ return _BaseInfo_SEOTitle; }
			set{ _BaseInfo_SEOTitle = value; }
		}
		private System.String _BaseInfo_SEOKeyWord;
		public System.String BaseInfo_SEOKeyWord
		{
			get{ return _BaseInfo_SEOKeyWord; }
			set{ _BaseInfo_SEOKeyWord = value; }
		}
		private System.String _BaseInfo_SEODescription;
		public System.String BaseInfo_SEODescription
		{
			get{ return _BaseInfo_SEODescription; }
			set{ _BaseInfo_SEODescription = value; }
		}
		private System.String _BaseInfo_ExFlag1;
		public System.String BaseInfo_ExFlag1
		{
			get{ return _BaseInfo_ExFlag1; }
			set{ _BaseInfo_ExFlag1 = value; }
		}
		private System.String _BaseInfo_ExFlag2;
		public System.String BaseInfo_ExFlag2
		{
			get{ return _BaseInfo_ExFlag2; }
			set{ _BaseInfo_ExFlag2 = value; }
		}
		private System.String _BaseInfo_ExFlag3;
		public System.String BaseInfo_ExFlag3
		{
			get{ return _BaseInfo_ExFlag3; }
			set{ _BaseInfo_ExFlag3 = value; }
		}
		private System.String _BaseInfo_ExFlag4;
		public System.String BaseInfo_ExFlag4
		{
			get{ return _BaseInfo_ExFlag4; }
			set{ _BaseInfo_ExFlag4 = value; }
		}
		private System.String _BaseInfo_ExFlag5;
		public System.String BaseInfo_ExFlag5
		{
			get{ return _BaseInfo_ExFlag5; }
			set{ _BaseInfo_ExFlag5 = value; }
		}
		private System.String _BaseInfo_ExFlag6;
		public System.String BaseInfo_ExFlag6
		{
			get{ return _BaseInfo_ExFlag6; }
			set{ _BaseInfo_ExFlag6 = value; }
		}
		private System.String _BaseInfo_ExFlag7;
		public System.String BaseInfo_ExFlag7
		{
			get{ return _BaseInfo_ExFlag7; }
			set{ _BaseInfo_ExFlag7 = value; }
		}
		private System.String _BaseInfo_ExFlag8;
		public System.String BaseInfo_ExFlag8
		{
			get{ return _BaseInfo_ExFlag8; }
			set{ _BaseInfo_ExFlag8 = value; }
		}
		private System.String _BaseInfo_ExFlag9;
		public System.String BaseInfo_ExFlag9
		{
			get{ return _BaseInfo_ExFlag9; }
			set{ _BaseInfo_ExFlag9 = value; }
		}
		private System.String _BaseInfo_ExFlag10;
		public System.String BaseInfo_ExFlag10
		{
			get{ return _BaseInfo_ExFlag10; }
			set{ _BaseInfo_ExFlag10 = value; }
		}


		public static Exp _BASEINFO_ID_ = new Exp("BaseInfo_Id");
		public static Exp _BASEINFO_CATEID_ = new Exp("BaseInfo_CateId");
		public static Exp _BASEINFO_CATENAME_ = new Exp("BaseInfo_CateName");
		public static Exp _BASEINFO_TITLE_ = new Exp("BaseInfo_Title");
		public static Exp _BASEINFO_STATE_ = new Exp("BaseInfo_State");
		public static Exp _BASEINFO_IMAGE_ = new Exp("BaseInfo_Image");
		public static Exp _BASEINFO_CONTENT_ = new Exp("BaseInfo_Content");
		public static Exp _BASEINFO_ORDER_ = new Exp("BaseInfo_Order");
		public static Exp _BASEINFO_ADDTIME_ = new Exp("BaseInfo_AddTime");
		public static Exp _BASEINFO_SEOTITLE_ = new Exp("BaseInfo_SEOTitle");
		public static Exp _BASEINFO_SEOKEYWORD_ = new Exp("BaseInfo_SEOKeyWord");
		public static Exp _BASEINFO_SEODESCRIPTION_ = new Exp("BaseInfo_SEODescription");
		public static Exp _BASEINFO_EXFLAG1_ = new Exp("BaseInfo_ExFlag1");
		public static Exp _BASEINFO_EXFLAG2_ = new Exp("BaseInfo_ExFlag2");
		public static Exp _BASEINFO_EXFLAG3_ = new Exp("BaseInfo_ExFlag3");
		public static Exp _BASEINFO_EXFLAG4_ = new Exp("BaseInfo_ExFlag4");
		public static Exp _BASEINFO_EXFLAG5_ = new Exp("BaseInfo_ExFlag5");
		public static Exp _BASEINFO_EXFLAG6_ = new Exp("BaseInfo_ExFlag6");
		public static Exp _BASEINFO_EXFLAG7_ = new Exp("BaseInfo_ExFlag7");
		public static Exp _BASEINFO_EXFLAG8_ = new Exp("BaseInfo_ExFlag8");
		public static Exp _BASEINFO_EXFLAG9_ = new Exp("BaseInfo_ExFlag9");
		public static Exp _BASEINFO_EXFLAG10_ = new Exp("BaseInfo_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@BaseInfo_Id",SqlDbType.Int);
			p.Value = _BaseInfo_Id;
			rs.Add(p);
			p = new SqlParameter("@BaseInfo_CateId",SqlDbType.Int);
			p.Value = _BaseInfo_CateId;
			rs.Add(p);
			if (_BaseInfo_CateName != null)
			{
				p = new SqlParameter("@BaseInfo_CateName",SqlDbType.NVarChar);
				p.Value = _BaseInfo_CateName;
				rs.Add(p);
			}
			if (_BaseInfo_Title != null)
			{
				p = new SqlParameter("@BaseInfo_Title",SqlDbType.NVarChar);
				p.Value = _BaseInfo_Title;
				rs.Add(p);
			}
			if (_BaseInfo_State != null)
			{
				p = new SqlParameter("@BaseInfo_State",SqlDbType.NVarChar);
				p.Value = _BaseInfo_State;
				rs.Add(p);
			}
			if (_BaseInfo_Image != null)
			{
				p = new SqlParameter("@BaseInfo_Image",SqlDbType.NVarChar);
				p.Value = _BaseInfo_Image;
				rs.Add(p);
			}
			if (_BaseInfo_Content != null)
			{
				p = new SqlParameter("@BaseInfo_Content",SqlDbType.NText);
				p.Value = _BaseInfo_Content;
				rs.Add(p);
			}
			p = new SqlParameter("@BaseInfo_Order",SqlDbType.Int);
			p.Value = _BaseInfo_Order;
			rs.Add(p);
			if (_BaseInfo_AddTime != null)
			{
				if (_BaseInfo_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@BaseInfo_AddTime",SqlDbType.SmallDateTime);
					p.Value = _BaseInfo_AddTime;
					rs.Add(p);
				}
			}
			if (_BaseInfo_SEOTitle != null)
			{
				p = new SqlParameter("@BaseInfo_SEOTitle",SqlDbType.NVarChar);
				p.Value = _BaseInfo_SEOTitle;
				rs.Add(p);
			}
			if (_BaseInfo_SEOKeyWord != null)
			{
				p = new SqlParameter("@BaseInfo_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _BaseInfo_SEOKeyWord;
				rs.Add(p);
			}
			if (_BaseInfo_SEODescription != null)
			{
				p = new SqlParameter("@BaseInfo_SEODescription",SqlDbType.NVarChar);
				p.Value = _BaseInfo_SEODescription;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag1 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag1",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag1;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag2 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag2",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag2;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag3 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag3",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag3;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag4 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag4",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag4;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag5 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag5",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag5;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag6 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag6",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag6;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag7 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag7",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag7;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag8 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag8",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag8;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag9 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag9",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag9;
				rs.Add(p);
			}
			if (_BaseInfo_ExFlag10 != null)
			{
				p = new SqlParameter("@BaseInfo_ExFlag10",SqlDbType.NText);
				p.Value = _BaseInfo_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_Id")))
			{
				_BaseInfo_Id = (System.Int32)Rd["BaseInfo_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_CateId")))
			{
				_BaseInfo_CateId = (System.Int32)Rd["BaseInfo_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_CateName")))
			{
				_BaseInfo_CateName = (System.String)Rd["BaseInfo_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_Title")))
			{
				_BaseInfo_Title = (System.String)Rd["BaseInfo_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_State")))
			{
				_BaseInfo_State = (System.String)Rd["BaseInfo_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_Image")))
			{
				_BaseInfo_Image = (System.String)Rd["BaseInfo_Image"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_Content")))
			{
				_BaseInfo_Content = (System.String)Rd["BaseInfo_Content"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_Order")))
			{
				_BaseInfo_Order = (System.Int32)Rd["BaseInfo_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_AddTime")))
			{
				_BaseInfo_AddTime = (System.DateTime)Rd["BaseInfo_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_SEOTitle")))
			{
				_BaseInfo_SEOTitle = (System.String)Rd["BaseInfo_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_SEOKeyWord")))
			{
				_BaseInfo_SEOKeyWord = (System.String)Rd["BaseInfo_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_SEODescription")))
			{
				_BaseInfo_SEODescription = (System.String)Rd["BaseInfo_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag1")))
			{
				_BaseInfo_ExFlag1 = (System.String)Rd["BaseInfo_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag2")))
			{
				_BaseInfo_ExFlag2 = (System.String)Rd["BaseInfo_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag3")))
			{
				_BaseInfo_ExFlag3 = (System.String)Rd["BaseInfo_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag4")))
			{
				_BaseInfo_ExFlag4 = (System.String)Rd["BaseInfo_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag5")))
			{
				_BaseInfo_ExFlag5 = (System.String)Rd["BaseInfo_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag6")))
			{
				_BaseInfo_ExFlag6 = (System.String)Rd["BaseInfo_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag7")))
			{
				_BaseInfo_ExFlag7 = (System.String)Rd["BaseInfo_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag8")))
			{
				_BaseInfo_ExFlag8 = (System.String)Rd["BaseInfo_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag9")))
			{
				_BaseInfo_ExFlag9 = (System.String)Rd["BaseInfo_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("BaseInfo_ExFlag10")))
			{
				_BaseInfo_ExFlag10 = (System.String)Rd["BaseInfo_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_BaseInfo();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_BaseInfo([BaseInfo_CateId],[BaseInfo_CateName],[BaseInfo_Title],[BaseInfo_State],[BaseInfo_Image],[BaseInfo_Content],[BaseInfo_Order],[BaseInfo_AddTime],[BaseInfo_SEOTitle],[BaseInfo_SEOKeyWord],[BaseInfo_SEODescription],[BaseInfo_ExFlag1],[BaseInfo_ExFlag2],[BaseInfo_ExFlag3],[BaseInfo_ExFlag4],[BaseInfo_ExFlag5],[BaseInfo_ExFlag6],[BaseInfo_ExFlag7],[BaseInfo_ExFlag8],[BaseInfo_ExFlag9],[BaseInfo_ExFlag10]) VALUES (@BaseInfo_CateId ,@BaseInfo_CateName ,@BaseInfo_Title ,@BaseInfo_State ,@BaseInfo_Image ,@BaseInfo_Content ,@BaseInfo_Order ,@BaseInfo_AddTime ,@BaseInfo_SEOTitle ,@BaseInfo_SEOKeyWord ,@BaseInfo_SEODescription ,@BaseInfo_ExFlag1 ,@BaseInfo_ExFlag2 ,@BaseInfo_ExFlag3 ,@BaseInfo_ExFlag4 ,@BaseInfo_ExFlag5 ,@BaseInfo_ExFlag6 ,@BaseInfo_ExFlag7 ,@BaseInfo_ExFlag8 ,@BaseInfo_ExFlag9 ,@BaseInfo_ExFlag10 )";
		}


	}

	public class Dcms_Cate:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Cate_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Cate";
		}

		private System.Int32 _Cate_Id;
		public System.Int32 Cate_Id
		{
			get{ return _Cate_Id; }
			set{ _Cate_Id = value; }
		}
		private System.String _Cate_Title;
		public System.String Cate_Title
		{
			get{ return _Cate_Title; }
			set{ _Cate_Title = value; }
		}
		private System.String _Cate_IdPath;
		public System.String Cate_IdPath
		{
			get{ return _Cate_IdPath; }
			set{ _Cate_IdPath = value; }
		}
		private System.String _Cate_Image;
		public System.String Cate_Image
		{
			get{ return _Cate_Image; }
			set{ _Cate_Image = value; }
		}
		private System.String _Cate_Intro;
		public System.String Cate_Intro
		{
			get{ return _Cate_Intro; }
			set{ _Cate_Intro = value; }
		}
		private System.Int32 _Cate_HasChild;
		public System.Int32 Cate_HasChild
		{
			get{ return _Cate_HasChild; }
			set{ _Cate_HasChild = value; }
		}
		private System.String _Cate_Key;
		public System.String Cate_Key
		{
			get{ return _Cate_Key; }
			set{ _Cate_Key = value; }
		}
		private System.String _Cate_Lang;
		public System.String Cate_Lang
		{
			get{ return _Cate_Lang; }
			set{ _Cate_Lang = value; }
		}
		private System.DateTime _Cate_AddTime;
		public System.DateTime Cate_AddTime
		{
			get{ return _Cate_AddTime; }
			set{ _Cate_AddTime = value; }
		}
		private System.Int32 _Cate_Order;
		public System.Int32 Cate_Order
		{
			get{ return _Cate_Order; }
			set{ _Cate_Order = value; }
		}
		private System.Int32 _Cate_ParentID;
		public System.Int32 Cate_ParentID
		{
			get{ return _Cate_ParentID; }
			set{ _Cate_ParentID = value; }
		}
		private System.String _Cate_Url;
		public System.String Cate_Url
		{
			get{ return _Cate_Url; }
			set{ _Cate_Url = value; }
		}
		private System.String _Cate_Module;
		public System.String Cate_Module
		{
			get{ return _Cate_Module; }
			set{ _Cate_Module = value; }
		}
		private System.String _Cate_ManageUrl;
		public System.String Cate_ManageUrl
		{
			get{ return _Cate_ManageUrl; }
			set{ _Cate_ManageUrl = value; }
		}
		private System.String _Cate_ManageName;
		public System.String Cate_ManageName
		{
			get{ return _Cate_ManageName; }
			set{ _Cate_ManageName = value; }
		}
		private System.String _Cate_State;
		public System.String Cate_State
		{
			get{ return _Cate_State; }
			set{ _Cate_State = value; }
		}
		private System.String _Cate_IsMenu;
		public System.String Cate_IsMenu
		{
			get{ return _Cate_IsMenu; }
			set{ _Cate_IsMenu = value; }
		}
		private System.String _Cate_Guid;
		public System.String Cate_Guid
		{
			get{ return _Cate_Guid; }
			set{ _Cate_Guid = value; }
		}
		private System.String _Cate_ModelKeyId;
		public System.String Cate_ModelKeyId
		{
			get{ return _Cate_ModelKeyId; }
			set{ _Cate_ModelKeyId = value; }
		}
		private System.String _Cate_SEOTitle;
		public System.String Cate_SEOTitle
		{
			get{ return _Cate_SEOTitle; }
			set{ _Cate_SEOTitle = value; }
		}
		private System.String _Cate_SEOKeyWord;
		public System.String Cate_SEOKeyWord
		{
			get{ return _Cate_SEOKeyWord; }
			set{ _Cate_SEOKeyWord = value; }
		}
		private System.String _Cate_SEODescription;
		public System.String Cate_SEODescription
		{
			get{ return _Cate_SEODescription; }
			set{ _Cate_SEODescription = value; }
		}
		private System.String _Cate_ExField1;
		public System.String Cate_ExField1
		{
			get{ return _Cate_ExField1; }
			set{ _Cate_ExField1 = value; }
		}
		private System.String _Cate_ExField2;
		public System.String Cate_ExField2
		{
			get{ return _Cate_ExField2; }
			set{ _Cate_ExField2 = value; }
		}
		private System.String _Cate_ExField3;
		public System.String Cate_ExField3
		{
			get{ return _Cate_ExField3; }
			set{ _Cate_ExField3 = value; }
		}
		private System.String _Cate_ExField4;
		public System.String Cate_ExField4
		{
			get{ return _Cate_ExField4; }
			set{ _Cate_ExField4 = value; }
		}
		private System.String _Cate_ExField5;
		public System.String Cate_ExField5
		{
			get{ return _Cate_ExField5; }
			set{ _Cate_ExField5 = value; }
		}
		private System.String _Cate_ExField6;
		public System.String Cate_ExField6
		{
			get{ return _Cate_ExField6; }
			set{ _Cate_ExField6 = value; }
		}
		private System.String _Cate_ExField7;
		public System.String Cate_ExField7
		{
			get{ return _Cate_ExField7; }
			set{ _Cate_ExField7 = value; }
		}
		private System.String _Cate_ExField8;
		public System.String Cate_ExField8
		{
			get{ return _Cate_ExField8; }
			set{ _Cate_ExField8 = value; }
		}
		private System.String _Cate_ExField9;
		public System.String Cate_ExField9
		{
			get{ return _Cate_ExField9; }
			set{ _Cate_ExField9 = value; }
		}
		private System.String _Cate_ExField10;
		public System.String Cate_ExField10
		{
			get{ return _Cate_ExField10; }
			set{ _Cate_ExField10 = value; }
		}


		public static Exp _CATE_ID_ = new Exp("Cate_Id");
		public static Exp _CATE_TITLE_ = new Exp("Cate_Title");
		public static Exp _CATE_IDPATH_ = new Exp("Cate_IdPath");
		public static Exp _CATE_IMAGE_ = new Exp("Cate_Image");
		public static Exp _CATE_INTRO_ = new Exp("Cate_Intro");
		public static Exp _CATE_HASCHILD_ = new Exp("Cate_HasChild");
		public static Exp _CATE_KEY_ = new Exp("Cate_Key");
		public static Exp _CATE_LANG_ = new Exp("Cate_Lang");
		public static Exp _CATE_ADDTIME_ = new Exp("Cate_AddTime");
		public static Exp _CATE_ORDER_ = new Exp("Cate_Order");
		public static Exp _CATE_PARENTID_ = new Exp("Cate_ParentID");
		public static Exp _CATE_URL_ = new Exp("Cate_Url");
		public static Exp _CATE_MODULE_ = new Exp("Cate_Module");
		public static Exp _CATE_MANAGEURL_ = new Exp("Cate_ManageUrl");
		public static Exp _CATE_MANAGENAME_ = new Exp("Cate_ManageName");
		public static Exp _CATE_STATE_ = new Exp("Cate_State");
		public static Exp _CATE_ISMENU_ = new Exp("Cate_IsMenu");
		public static Exp _CATE_GUID_ = new Exp("Cate_Guid");
		public static Exp _CATE_MODELKEYID_ = new Exp("Cate_ModelKeyId");
		public static Exp _CATE_SEOTITLE_ = new Exp("Cate_SEOTitle");
		public static Exp _CATE_SEOKEYWORD_ = new Exp("Cate_SEOKeyWord");
		public static Exp _CATE_SEODESCRIPTION_ = new Exp("Cate_SEODescription");
		public static Exp _CATE_EXFIELD1_ = new Exp("Cate_ExField1");
		public static Exp _CATE_EXFIELD2_ = new Exp("Cate_ExField2");
		public static Exp _CATE_EXFIELD3_ = new Exp("Cate_ExField3");
		public static Exp _CATE_EXFIELD4_ = new Exp("Cate_ExField4");
		public static Exp _CATE_EXFIELD5_ = new Exp("Cate_ExField5");
		public static Exp _CATE_EXFIELD6_ = new Exp("Cate_ExField6");
		public static Exp _CATE_EXFIELD7_ = new Exp("Cate_ExField7");
		public static Exp _CATE_EXFIELD8_ = new Exp("Cate_ExField8");
		public static Exp _CATE_EXFIELD9_ = new Exp("Cate_ExField9");
		public static Exp _CATE_EXFIELD10_ = new Exp("Cate_ExField10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Cate_Id",SqlDbType.Int);
			p.Value = _Cate_Id;
			rs.Add(p);
			if (_Cate_Title != null)
			{
				p = new SqlParameter("@Cate_Title",SqlDbType.NVarChar);
				p.Value = _Cate_Title;
				rs.Add(p);
			}
			if (_Cate_IdPath != null)
			{
				p = new SqlParameter("@Cate_IdPath",SqlDbType.NVarChar);
				p.Value = _Cate_IdPath;
				rs.Add(p);
			}
			if (_Cate_Image != null)
			{
				p = new SqlParameter("@Cate_Image",SqlDbType.NText);
				p.Value = _Cate_Image;
				rs.Add(p);
			}
			if (_Cate_Intro != null)
			{
				p = new SqlParameter("@Cate_Intro",SqlDbType.NText);
				p.Value = _Cate_Intro;
				rs.Add(p);
			}
			p = new SqlParameter("@Cate_HasChild",SqlDbType.Int);
			p.Value = _Cate_HasChild;
			rs.Add(p);
			if (_Cate_Key != null)
			{
				p = new SqlParameter("@Cate_Key",SqlDbType.NVarChar);
				p.Value = _Cate_Key;
				rs.Add(p);
			}
			if (_Cate_Lang != null)
			{
				p = new SqlParameter("@Cate_Lang",SqlDbType.NVarChar);
				p.Value = _Cate_Lang;
				rs.Add(p);
			}
			if (_Cate_AddTime != null)
			{
				if (_Cate_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Cate_AddTime",SqlDbType.SmallDateTime);
					p.Value = _Cate_AddTime;
					rs.Add(p);
				}
			}
			p = new SqlParameter("@Cate_Order",SqlDbType.Int);
			p.Value = _Cate_Order;
			rs.Add(p);
			p = new SqlParameter("@Cate_ParentID",SqlDbType.Int);
			p.Value = _Cate_ParentID;
			rs.Add(p);
			if (_Cate_Url != null)
			{
				p = new SqlParameter("@Cate_Url",SqlDbType.NVarChar);
				p.Value = _Cate_Url;
				rs.Add(p);
			}
			if (_Cate_Module != null)
			{
				p = new SqlParameter("@Cate_Module",SqlDbType.NVarChar);
				p.Value = _Cate_Module;
				rs.Add(p);
			}
			if (_Cate_ManageUrl != null)
			{
				p = new SqlParameter("@Cate_ManageUrl",SqlDbType.NVarChar);
				p.Value = _Cate_ManageUrl;
				rs.Add(p);
			}
			if (_Cate_ManageName != null)
			{
				p = new SqlParameter("@Cate_ManageName",SqlDbType.NVarChar);
				p.Value = _Cate_ManageName;
				rs.Add(p);
			}
			if (_Cate_State != null)
			{
				p = new SqlParameter("@Cate_State",SqlDbType.NVarChar);
				p.Value = _Cate_State;
				rs.Add(p);
			}
			if (_Cate_IsMenu != null)
			{
				p = new SqlParameter("@Cate_IsMenu",SqlDbType.NVarChar);
				p.Value = _Cate_IsMenu;
				rs.Add(p);
			}
			if (_Cate_Guid != null)
			{
				p = new SqlParameter("@Cate_Guid",SqlDbType.VarChar);
				p.Value = _Cate_Guid;
				rs.Add(p);
			}
			if (_Cate_ModelKeyId != null)
			{
				p = new SqlParameter("@Cate_ModelKeyId",SqlDbType.NVarChar);
				p.Value = _Cate_ModelKeyId;
				rs.Add(p);
			}
			if (_Cate_SEOTitle != null)
			{
				p = new SqlParameter("@Cate_SEOTitle",SqlDbType.NVarChar);
				p.Value = _Cate_SEOTitle;
				rs.Add(p);
			}
			if (_Cate_SEOKeyWord != null)
			{
				p = new SqlParameter("@Cate_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _Cate_SEOKeyWord;
				rs.Add(p);
			}
			if (_Cate_SEODescription != null)
			{
				p = new SqlParameter("@Cate_SEODescription",SqlDbType.NVarChar);
				p.Value = _Cate_SEODescription;
				rs.Add(p);
			}
			if (_Cate_ExField1 != null)
			{
				p = new SqlParameter("@Cate_ExField1",SqlDbType.NText);
				p.Value = _Cate_ExField1;
				rs.Add(p);
			}
			if (_Cate_ExField2 != null)
			{
				p = new SqlParameter("@Cate_ExField2",SqlDbType.NText);
				p.Value = _Cate_ExField2;
				rs.Add(p);
			}
			if (_Cate_ExField3 != null)
			{
				p = new SqlParameter("@Cate_ExField3",SqlDbType.NText);
				p.Value = _Cate_ExField3;
				rs.Add(p);
			}
			if (_Cate_ExField4 != null)
			{
				p = new SqlParameter("@Cate_ExField4",SqlDbType.NText);
				p.Value = _Cate_ExField4;
				rs.Add(p);
			}
			if (_Cate_ExField5 != null)
			{
				p = new SqlParameter("@Cate_ExField5",SqlDbType.NText);
				p.Value = _Cate_ExField5;
				rs.Add(p);
			}
			if (_Cate_ExField6 != null)
			{
				p = new SqlParameter("@Cate_ExField6",SqlDbType.NText);
				p.Value = _Cate_ExField6;
				rs.Add(p);
			}
			if (_Cate_ExField7 != null)
			{
				p = new SqlParameter("@Cate_ExField7",SqlDbType.NText);
				p.Value = _Cate_ExField7;
				rs.Add(p);
			}
			if (_Cate_ExField8 != null)
			{
				p = new SqlParameter("@Cate_ExField8",SqlDbType.NText);
				p.Value = _Cate_ExField8;
				rs.Add(p);
			}
			if (_Cate_ExField9 != null)
			{
				p = new SqlParameter("@Cate_ExField9",SqlDbType.NText);
				p.Value = _Cate_ExField9;
				rs.Add(p);
			}
			if (_Cate_ExField10 != null)
			{
				p = new SqlParameter("@Cate_ExField10",SqlDbType.NText);
				p.Value = _Cate_ExField10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Id")))
			{
				_Cate_Id = (System.Int32)Rd["Cate_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Title")))
			{
				_Cate_Title = (System.String)Rd["Cate_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_IdPath")))
			{
				_Cate_IdPath = (System.String)Rd["Cate_IdPath"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Image")))
			{
				_Cate_Image = (System.String)Rd["Cate_Image"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Intro")))
			{
				_Cate_Intro = (System.String)Rd["Cate_Intro"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_HasChild")))
			{
				_Cate_HasChild = (System.Int32)Rd["Cate_HasChild"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Key")))
			{
				_Cate_Key = (System.String)Rd["Cate_Key"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Lang")))
			{
				_Cate_Lang = (System.String)Rd["Cate_Lang"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_AddTime")))
			{
				_Cate_AddTime = (System.DateTime)Rd["Cate_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Order")))
			{
				_Cate_Order = (System.Int32)Rd["Cate_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ParentID")))
			{
				_Cate_ParentID = (System.Int32)Rd["Cate_ParentID"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Url")))
			{
				_Cate_Url = (System.String)Rd["Cate_Url"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Module")))
			{
				_Cate_Module = (System.String)Rd["Cate_Module"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ManageUrl")))
			{
				_Cate_ManageUrl = (System.String)Rd["Cate_ManageUrl"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ManageName")))
			{
				_Cate_ManageName = (System.String)Rd["Cate_ManageName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_State")))
			{
				_Cate_State = (System.String)Rd["Cate_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_IsMenu")))
			{
				_Cate_IsMenu = (System.String)Rd["Cate_IsMenu"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_Guid")))
			{
				_Cate_Guid = (System.String)Rd["Cate_Guid"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ModelKeyId")))
			{
				_Cate_ModelKeyId = (System.String)Rd["Cate_ModelKeyId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_SEOTitle")))
			{
				_Cate_SEOTitle = (System.String)Rd["Cate_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_SEOKeyWord")))
			{
				_Cate_SEOKeyWord = (System.String)Rd["Cate_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_SEODescription")))
			{
				_Cate_SEODescription = (System.String)Rd["Cate_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField1")))
			{
				_Cate_ExField1 = (System.String)Rd["Cate_ExField1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField2")))
			{
				_Cate_ExField2 = (System.String)Rd["Cate_ExField2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField3")))
			{
				_Cate_ExField3 = (System.String)Rd["Cate_ExField3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField4")))
			{
				_Cate_ExField4 = (System.String)Rd["Cate_ExField4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField5")))
			{
				_Cate_ExField5 = (System.String)Rd["Cate_ExField5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField6")))
			{
				_Cate_ExField6 = (System.String)Rd["Cate_ExField6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField7")))
			{
				_Cate_ExField7 = (System.String)Rd["Cate_ExField7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField8")))
			{
				_Cate_ExField8 = (System.String)Rd["Cate_ExField8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField9")))
			{
				_Cate_ExField9 = (System.String)Rd["Cate_ExField9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Cate_ExField10")))
			{
				_Cate_ExField10 = (System.String)Rd["Cate_ExField10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Cate();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Cate([Cate_Title],[Cate_IdPath],[Cate_Image],[Cate_Intro],[Cate_HasChild],[Cate_Key],[Cate_Lang],[Cate_AddTime],[Cate_Order],[Cate_ParentID],[Cate_Url],[Cate_Module],[Cate_ManageUrl],[Cate_ManageName],[Cate_State],[Cate_IsMenu],[Cate_Guid],[Cate_ModelKeyId],[Cate_SEOTitle],[Cate_SEOKeyWord],[Cate_SEODescription],[Cate_ExField1],[Cate_ExField2],[Cate_ExField3],[Cate_ExField4],[Cate_ExField5],[Cate_ExField6],[Cate_ExField7],[Cate_ExField8],[Cate_ExField9],[Cate_ExField10]) VALUES (@Cate_Title ,@Cate_IdPath ,@Cate_Image ,@Cate_Intro ,@Cate_HasChild ,@Cate_Key ,@Cate_Lang ,@Cate_AddTime ,@Cate_Order ,@Cate_ParentID ,@Cate_Url ,@Cate_Module ,@Cate_ManageUrl ,@Cate_ManageName ,@Cate_State ,@Cate_IsMenu ,@Cate_Guid ,@Cate_ModelKeyId ,@Cate_SEOTitle ,@Cate_SEOKeyWord ,@Cate_SEODescription ,@Cate_ExField1 ,@Cate_ExField2 ,@Cate_ExField3 ,@Cate_ExField4 ,@Cate_ExField5 ,@Cate_ExField6 ,@Cate_ExField7 ,@Cate_ExField8 ,@Cate_ExField9 ,@Cate_ExField10 )";
		}


	}

	public class Dcms_Down:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Down_ID";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Down";
		}

		private System.Int32 _Down_ID;
		public System.Int32 Down_ID
		{
			get{ return _Down_ID; }
			set{ _Down_ID = value; }
		}
		private System.Int32 _Down_CateID;
		public System.Int32 Down_CateID
		{
			get{ return _Down_CateID; }
			set{ _Down_CateID = value; }
		}
		private System.String _Down_CateName;
		public System.String Down_CateName
		{
			get{ return _Down_CateName; }
			set{ _Down_CateName = value; }
		}
		private System.String _Down_FileType;
		public System.String Down_FileType
		{
			get{ return _Down_FileType; }
			set{ _Down_FileType = value; }
		}
		private System.String _Down_Title;
		public System.String Down_Title
		{
			get{ return _Down_Title; }
			set{ _Down_Title = value; }
		}
		private System.String _Down_FileSize;
		public System.String Down_FileSize
		{
			get{ return _Down_FileSize; }
			set{ _Down_FileSize = value; }
		}
		private System.String _Down_Image;
		public System.String Down_Image
		{
			get{ return _Down_Image; }
			set{ _Down_Image = value; }
		}
		private System.String _Down_LocalPath;
		public System.String Down_LocalPath
		{
			get{ return _Down_LocalPath; }
			set{ _Down_LocalPath = value; }
		}
		private System.String _Down_OtherPath;
		public System.String Down_OtherPath
		{
			get{ return _Down_OtherPath; }
			set{ _Down_OtherPath = value; }
		}
		private System.String _Down_Content;
		public System.String Down_Content
		{
			get{ return _Down_Content; }
			set{ _Down_Content = value; }
		}
		private System.String _Down_State;
		public System.String Down_State
		{
			get{ return _Down_State; }
			set{ _Down_State = value; }
		}
		private System.DateTime _Down_AddTime;
		public System.DateTime Down_AddTime
		{
			get{ return _Down_AddTime; }
			set{ _Down_AddTime = value; }
		}
		private System.String _Down_SEOTitle;
		public System.String Down_SEOTitle
		{
			get{ return _Down_SEOTitle; }
			set{ _Down_SEOTitle = value; }
		}
		private System.String _Down_SEOKeyWord;
		public System.String Down_SEOKeyWord
		{
			get{ return _Down_SEOKeyWord; }
			set{ _Down_SEOKeyWord = value; }
		}
		private System.String _Down_SEODescription;
		public System.String Down_SEODescription
		{
			get{ return _Down_SEODescription; }
			set{ _Down_SEODescription = value; }
		}
		private System.String _Down_ExFlag1;
		public System.String Down_ExFlag1
		{
			get{ return _Down_ExFlag1; }
			set{ _Down_ExFlag1 = value; }
		}
		private System.String _Down_ExFlag2;
		public System.String Down_ExFlag2
		{
			get{ return _Down_ExFlag2; }
			set{ _Down_ExFlag2 = value; }
		}
		private System.String _Down_ExFlag3;
		public System.String Down_ExFlag3
		{
			get{ return _Down_ExFlag3; }
			set{ _Down_ExFlag3 = value; }
		}
		private System.String _Down_ExFlag4;
		public System.String Down_ExFlag4
		{
			get{ return _Down_ExFlag4; }
			set{ _Down_ExFlag4 = value; }
		}
		private System.String _Down_ExFlag5;
		public System.String Down_ExFlag5
		{
			get{ return _Down_ExFlag5; }
			set{ _Down_ExFlag5 = value; }
		}
		private System.String _Down_ExFlag6;
		public System.String Down_ExFlag6
		{
			get{ return _Down_ExFlag6; }
			set{ _Down_ExFlag6 = value; }
		}
		private System.String _Down_ExFlag7;
		public System.String Down_ExFlag7
		{
			get{ return _Down_ExFlag7; }
			set{ _Down_ExFlag7 = value; }
		}
		private System.String _Down_ExFlag8;
		public System.String Down_ExFlag8
		{
			get{ return _Down_ExFlag8; }
			set{ _Down_ExFlag8 = value; }
		}
		private System.String _Down_ExFlag9;
		public System.String Down_ExFlag9
		{
			get{ return _Down_ExFlag9; }
			set{ _Down_ExFlag9 = value; }
		}
		private System.String _Down_ExFlag10;
		public System.String Down_ExFlag10
		{
			get{ return _Down_ExFlag10; }
			set{ _Down_ExFlag10 = value; }
		}


		public static Exp _DOWN_ID_ = new Exp("Down_ID");
		public static Exp _DOWN_CATEID_ = new Exp("Down_CateID");
		public static Exp _DOWN_CATENAME_ = new Exp("Down_CateName");
		public static Exp _DOWN_FILETYPE_ = new Exp("Down_FileType");
		public static Exp _DOWN_TITLE_ = new Exp("Down_Title");
		public static Exp _DOWN_FILESIZE_ = new Exp("Down_FileSize");
		public static Exp _DOWN_IMAGE_ = new Exp("Down_Image");
		public static Exp _DOWN_LOCALPATH_ = new Exp("Down_LocalPath");
		public static Exp _DOWN_OTHERPATH_ = new Exp("Down_OtherPath");
		public static Exp _DOWN_CONTENT_ = new Exp("Down_Content");
		public static Exp _DOWN_STATE_ = new Exp("Down_State");
		public static Exp _DOWN_ADDTIME_ = new Exp("Down_AddTime");
		public static Exp _DOWN_SEOTITLE_ = new Exp("Down_SEOTitle");
		public static Exp _DOWN_SEOKEYWORD_ = new Exp("Down_SEOKeyWord");
		public static Exp _DOWN_SEODESCRIPTION_ = new Exp("Down_SEODescription");
		public static Exp _DOWN_EXFLAG1_ = new Exp("Down_ExFlag1");
		public static Exp _DOWN_EXFLAG2_ = new Exp("Down_ExFlag2");
		public static Exp _DOWN_EXFLAG3_ = new Exp("Down_ExFlag3");
		public static Exp _DOWN_EXFLAG4_ = new Exp("Down_ExFlag4");
		public static Exp _DOWN_EXFLAG5_ = new Exp("Down_ExFlag5");
		public static Exp _DOWN_EXFLAG6_ = new Exp("Down_ExFlag6");
		public static Exp _DOWN_EXFLAG7_ = new Exp("Down_ExFlag7");
		public static Exp _DOWN_EXFLAG8_ = new Exp("Down_ExFlag8");
		public static Exp _DOWN_EXFLAG9_ = new Exp("Down_ExFlag9");
		public static Exp _DOWN_EXFLAG10_ = new Exp("Down_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Down_ID",SqlDbType.Int);
			p.Value = _Down_ID;
			rs.Add(p);
			p = new SqlParameter("@Down_CateID",SqlDbType.Int);
			p.Value = _Down_CateID;
			rs.Add(p);
			if (_Down_CateName != null)
			{
				p = new SqlParameter("@Down_CateName",SqlDbType.NVarChar);
				p.Value = _Down_CateName;
				rs.Add(p);
			}
			if (_Down_FileType != null)
			{
				p = new SqlParameter("@Down_FileType",SqlDbType.NVarChar);
				p.Value = _Down_FileType;
				rs.Add(p);
			}
			if (_Down_Title != null)
			{
				p = new SqlParameter("@Down_Title",SqlDbType.NVarChar);
				p.Value = _Down_Title;
				rs.Add(p);
			}
			if (_Down_FileSize != null)
			{
				p = new SqlParameter("@Down_FileSize",SqlDbType.NVarChar);
				p.Value = _Down_FileSize;
				rs.Add(p);
			}
			if (_Down_Image != null)
			{
				p = new SqlParameter("@Down_Image",SqlDbType.NVarChar);
				p.Value = _Down_Image;
				rs.Add(p);
			}
			if (_Down_LocalPath != null)
			{
				p = new SqlParameter("@Down_LocalPath",SqlDbType.NVarChar);
				p.Value = _Down_LocalPath;
				rs.Add(p);
			}
			if (_Down_OtherPath != null)
			{
				p = new SqlParameter("@Down_OtherPath",SqlDbType.NVarChar);
				p.Value = _Down_OtherPath;
				rs.Add(p);
			}
			if (_Down_Content != null)
			{
				p = new SqlParameter("@Down_Content",SqlDbType.NText);
				p.Value = _Down_Content;
				rs.Add(p);
			}
			if (_Down_State != null)
			{
				p = new SqlParameter("@Down_State",SqlDbType.NVarChar);
				p.Value = _Down_State;
				rs.Add(p);
			}
			if (_Down_AddTime != null)
			{
				if (_Down_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Down_AddTime",SqlDbType.SmallDateTime);
					p.Value = _Down_AddTime;
					rs.Add(p);
				}
			}
			if (_Down_SEOTitle != null)
			{
				p = new SqlParameter("@Down_SEOTitle",SqlDbType.NVarChar);
				p.Value = _Down_SEOTitle;
				rs.Add(p);
			}
			if (_Down_SEOKeyWord != null)
			{
				p = new SqlParameter("@Down_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _Down_SEOKeyWord;
				rs.Add(p);
			}
			if (_Down_SEODescription != null)
			{
				p = new SqlParameter("@Down_SEODescription",SqlDbType.NVarChar);
				p.Value = _Down_SEODescription;
				rs.Add(p);
			}
			if (_Down_ExFlag1 != null)
			{
				p = new SqlParameter("@Down_ExFlag1",SqlDbType.NText);
				p.Value = _Down_ExFlag1;
				rs.Add(p);
			}
			if (_Down_ExFlag2 != null)
			{
				p = new SqlParameter("@Down_ExFlag2",SqlDbType.NText);
				p.Value = _Down_ExFlag2;
				rs.Add(p);
			}
			if (_Down_ExFlag3 != null)
			{
				p = new SqlParameter("@Down_ExFlag3",SqlDbType.NText);
				p.Value = _Down_ExFlag3;
				rs.Add(p);
			}
			if (_Down_ExFlag4 != null)
			{
				p = new SqlParameter("@Down_ExFlag4",SqlDbType.NText);
				p.Value = _Down_ExFlag4;
				rs.Add(p);
			}
			if (_Down_ExFlag5 != null)
			{
				p = new SqlParameter("@Down_ExFlag5",SqlDbType.NText);
				p.Value = _Down_ExFlag5;
				rs.Add(p);
			}
			if (_Down_ExFlag6 != null)
			{
				p = new SqlParameter("@Down_ExFlag6",SqlDbType.NText);
				p.Value = _Down_ExFlag6;
				rs.Add(p);
			}
			if (_Down_ExFlag7 != null)
			{
				p = new SqlParameter("@Down_ExFlag7",SqlDbType.NText);
				p.Value = _Down_ExFlag7;
				rs.Add(p);
			}
			if (_Down_ExFlag8 != null)
			{
				p = new SqlParameter("@Down_ExFlag8",SqlDbType.NText);
				p.Value = _Down_ExFlag8;
				rs.Add(p);
			}
			if (_Down_ExFlag9 != null)
			{
				p = new SqlParameter("@Down_ExFlag9",SqlDbType.NText);
				p.Value = _Down_ExFlag9;
				rs.Add(p);
			}
			if (_Down_ExFlag10 != null)
			{
				p = new SqlParameter("@Down_ExFlag10",SqlDbType.NText);
				p.Value = _Down_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ID")))
			{
				_Down_ID = (System.Int32)Rd["Down_ID"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_CateID")))
			{
				_Down_CateID = (System.Int32)Rd["Down_CateID"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_CateName")))
			{
				_Down_CateName = (System.String)Rd["Down_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_FileType")))
			{
				_Down_FileType = (System.String)Rd["Down_FileType"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_Title")))
			{
				_Down_Title = (System.String)Rd["Down_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_FileSize")))
			{
				_Down_FileSize = (System.String)Rd["Down_FileSize"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_Image")))
			{
				_Down_Image = (System.String)Rd["Down_Image"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_LocalPath")))
			{
				_Down_LocalPath = (System.String)Rd["Down_LocalPath"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_OtherPath")))
			{
				_Down_OtherPath = (System.String)Rd["Down_OtherPath"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_Content")))
			{
				_Down_Content = (System.String)Rd["Down_Content"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_State")))
			{
				_Down_State = (System.String)Rd["Down_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_AddTime")))
			{
				_Down_AddTime = (System.DateTime)Rd["Down_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_SEOTitle")))
			{
				_Down_SEOTitle = (System.String)Rd["Down_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_SEOKeyWord")))
			{
				_Down_SEOKeyWord = (System.String)Rd["Down_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_SEODescription")))
			{
				_Down_SEODescription = (System.String)Rd["Down_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag1")))
			{
				_Down_ExFlag1 = (System.String)Rd["Down_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag2")))
			{
				_Down_ExFlag2 = (System.String)Rd["Down_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag3")))
			{
				_Down_ExFlag3 = (System.String)Rd["Down_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag4")))
			{
				_Down_ExFlag4 = (System.String)Rd["Down_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag5")))
			{
				_Down_ExFlag5 = (System.String)Rd["Down_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag6")))
			{
				_Down_ExFlag6 = (System.String)Rd["Down_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag7")))
			{
				_Down_ExFlag7 = (System.String)Rd["Down_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag8")))
			{
				_Down_ExFlag8 = (System.String)Rd["Down_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag9")))
			{
				_Down_ExFlag9 = (System.String)Rd["Down_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Down_ExFlag10")))
			{
				_Down_ExFlag10 = (System.String)Rd["Down_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Down();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Down([Down_CateID],[Down_CateName],[Down_FileType],[Down_Title],[Down_FileSize],[Down_Image],[Down_LocalPath],[Down_OtherPath],[Down_Content],[Down_State],[Down_AddTime],[Down_SEOTitle],[Down_SEOKeyWord],[Down_SEODescription],[Down_ExFlag1],[Down_ExFlag2],[Down_ExFlag3],[Down_ExFlag4],[Down_ExFlag5],[Down_ExFlag6],[Down_ExFlag7],[Down_ExFlag8],[Down_ExFlag9],[Down_ExFlag10]) VALUES (@Down_CateID ,@Down_CateName ,@Down_FileType ,@Down_Title ,@Down_FileSize ,@Down_Image ,@Down_LocalPath ,@Down_OtherPath ,@Down_Content ,@Down_State ,@Down_AddTime ,@Down_SEOTitle ,@Down_SEOKeyWord ,@Down_SEODescription ,@Down_ExFlag1 ,@Down_ExFlag2 ,@Down_ExFlag3 ,@Down_ExFlag4 ,@Down_ExFlag5 ,@Down_ExFlag6 ,@Down_ExFlag7 ,@Down_ExFlag8 ,@Down_ExFlag9 ,@Down_ExFlag10 )";
		}


	}

	public class Dcms_Ezine:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Ezine_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Ezine";
		}

		private System.Int32 _Ezine_Id;
		public System.Int32 Ezine_Id
		{
			get{ return _Ezine_Id; }
			set{ _Ezine_Id = value; }
		}
		private System.Int32 _Ezine_CateId;
		public System.Int32 Ezine_CateId
		{
			get{ return _Ezine_CateId; }
			set{ _Ezine_CateId = value; }
		}
		private System.String _Ezine_CateName;
		public System.String Ezine_CateName
		{
			get{ return _Ezine_CateName; }
			set{ _Ezine_CateName = value; }
		}
		private System.String _Ezine_Title;
		public System.String Ezine_Title
		{
			get{ return _Ezine_Title; }
			set{ _Ezine_Title = value; }
		}
		private System.Int32 _Ezine_Order;
		public System.Int32 Ezine_Order
		{
			get{ return _Ezine_Order; }
			set{ _Ezine_Order = value; }
		}
		private System.String _Ezine_MinImage;
		public System.String Ezine_MinImage
		{
			get{ return _Ezine_MinImage; }
			set{ _Ezine_MinImage = value; }
		}
		private System.String _Ezine_BigImage;
		public System.String Ezine_BigImage
		{
			get{ return _Ezine_BigImage; }
			set{ _Ezine_BigImage = value; }
		}
		private System.String _Ezine_State;
		public System.String Ezine_State
		{
			get{ return _Ezine_State; }
			set{ _Ezine_State = value; }
		}
		private System.DateTime _Ezine_AddTime;
		public System.DateTime Ezine_AddTime
		{
			get{ return _Ezine_AddTime; }
			set{ _Ezine_AddTime = value; }
		}
		private System.String _Ezine_ExFlag1;
		public System.String Ezine_ExFlag1
		{
			get{ return _Ezine_ExFlag1; }
			set{ _Ezine_ExFlag1 = value; }
		}
		private System.String _Ezine_ExFlag2;
		public System.String Ezine_ExFlag2
		{
			get{ return _Ezine_ExFlag2; }
			set{ _Ezine_ExFlag2 = value; }
		}
		private System.String _Ezine_ExFlag3;
		public System.String Ezine_ExFlag3
		{
			get{ return _Ezine_ExFlag3; }
			set{ _Ezine_ExFlag3 = value; }
		}
		private System.String _Ezine_ExFlag4;
		public System.String Ezine_ExFlag4
		{
			get{ return _Ezine_ExFlag4; }
			set{ _Ezine_ExFlag4 = value; }
		}
		private System.String _Ezine_ExFlag5;
		public System.String Ezine_ExFlag5
		{
			get{ return _Ezine_ExFlag5; }
			set{ _Ezine_ExFlag5 = value; }
		}
		private System.String _Ezine_ExFlag6;
		public System.String Ezine_ExFlag6
		{
			get{ return _Ezine_ExFlag6; }
			set{ _Ezine_ExFlag6 = value; }
		}
		private System.String _Ezine_ExFlag7;
		public System.String Ezine_ExFlag7
		{
			get{ return _Ezine_ExFlag7; }
			set{ _Ezine_ExFlag7 = value; }
		}
		private System.String _Ezine_ExFlag8;
		public System.String Ezine_ExFlag8
		{
			get{ return _Ezine_ExFlag8; }
			set{ _Ezine_ExFlag8 = value; }
		}
		private System.String _Ezine_ExFlag9;
		public System.String Ezine_ExFlag9
		{
			get{ return _Ezine_ExFlag9; }
			set{ _Ezine_ExFlag9 = value; }
		}
		private System.String _Ezine_ExFlag10;
		public System.String Ezine_ExFlag10
		{
			get{ return _Ezine_ExFlag10; }
			set{ _Ezine_ExFlag10 = value; }
		}


		public static Exp _EZINE_ID_ = new Exp("Ezine_Id");
		public static Exp _EZINE_CATEID_ = new Exp("Ezine_CateId");
		public static Exp _EZINE_CATENAME_ = new Exp("Ezine_CateName");
		public static Exp _EZINE_TITLE_ = new Exp("Ezine_Title");
		public static Exp _EZINE_ORDER_ = new Exp("Ezine_Order");
		public static Exp _EZINE_MINIMAGE_ = new Exp("Ezine_MinImage");
		public static Exp _EZINE_BIGIMAGE_ = new Exp("Ezine_BigImage");
		public static Exp _EZINE_STATE_ = new Exp("Ezine_State");
		public static Exp _EZINE_ADDTIME_ = new Exp("Ezine_AddTime");
		public static Exp _EZINE_EXFLAG1_ = new Exp("Ezine_ExFlag1");
		public static Exp _EZINE_EXFLAG2_ = new Exp("Ezine_ExFlag2");
		public static Exp _EZINE_EXFLAG3_ = new Exp("Ezine_ExFlag3");
		public static Exp _EZINE_EXFLAG4_ = new Exp("Ezine_ExFlag4");
		public static Exp _EZINE_EXFLAG5_ = new Exp("Ezine_ExFlag5");
		public static Exp _EZINE_EXFLAG6_ = new Exp("Ezine_ExFlag6");
		public static Exp _EZINE_EXFLAG7_ = new Exp("Ezine_ExFlag7");
		public static Exp _EZINE_EXFLAG8_ = new Exp("Ezine_ExFlag8");
		public static Exp _EZINE_EXFLAG9_ = new Exp("Ezine_ExFlag9");
		public static Exp _EZINE_EXFLAG10_ = new Exp("Ezine_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Ezine_Id",SqlDbType.Int);
			p.Value = _Ezine_Id;
			rs.Add(p);
			p = new SqlParameter("@Ezine_CateId",SqlDbType.Int);
			p.Value = _Ezine_CateId;
			rs.Add(p);
			if (_Ezine_CateName != null)
			{
				p = new SqlParameter("@Ezine_CateName",SqlDbType.NVarChar);
				p.Value = _Ezine_CateName;
				rs.Add(p);
			}
			if (_Ezine_Title != null)
			{
				p = new SqlParameter("@Ezine_Title",SqlDbType.NVarChar);
				p.Value = _Ezine_Title;
				rs.Add(p);
			}
			p = new SqlParameter("@Ezine_Order",SqlDbType.Int);
			p.Value = _Ezine_Order;
			rs.Add(p);
			if (_Ezine_MinImage != null)
			{
				p = new SqlParameter("@Ezine_MinImage",SqlDbType.NVarChar);
				p.Value = _Ezine_MinImage;
				rs.Add(p);
			}
			if (_Ezine_BigImage != null)
			{
				p = new SqlParameter("@Ezine_BigImage",SqlDbType.NVarChar);
				p.Value = _Ezine_BigImage;
				rs.Add(p);
			}
			if (_Ezine_State != null)
			{
				p = new SqlParameter("@Ezine_State",SqlDbType.NVarChar);
				p.Value = _Ezine_State;
				rs.Add(p);
			}
			if (_Ezine_AddTime != null)
			{
				if (_Ezine_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Ezine_AddTime",SqlDbType.DateTime);
					p.Value = _Ezine_AddTime;
					rs.Add(p);
				}
			}
			if (_Ezine_ExFlag1 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag1",SqlDbType.Text);
				p.Value = _Ezine_ExFlag1;
				rs.Add(p);
			}
			if (_Ezine_ExFlag2 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag2",SqlDbType.Text);
				p.Value = _Ezine_ExFlag2;
				rs.Add(p);
			}
			if (_Ezine_ExFlag3 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag3",SqlDbType.Text);
				p.Value = _Ezine_ExFlag3;
				rs.Add(p);
			}
			if (_Ezine_ExFlag4 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag4",SqlDbType.Text);
				p.Value = _Ezine_ExFlag4;
				rs.Add(p);
			}
			if (_Ezine_ExFlag5 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag5",SqlDbType.Text);
				p.Value = _Ezine_ExFlag5;
				rs.Add(p);
			}
			if (_Ezine_ExFlag6 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag6",SqlDbType.Text);
				p.Value = _Ezine_ExFlag6;
				rs.Add(p);
			}
			if (_Ezine_ExFlag7 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag7",SqlDbType.Text);
				p.Value = _Ezine_ExFlag7;
				rs.Add(p);
			}
			if (_Ezine_ExFlag8 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag8",SqlDbType.Text);
				p.Value = _Ezine_ExFlag8;
				rs.Add(p);
			}
			if (_Ezine_ExFlag9 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag9",SqlDbType.Text);
				p.Value = _Ezine_ExFlag9;
				rs.Add(p);
			}
			if (_Ezine_ExFlag10 != null)
			{
				p = new SqlParameter("@Ezine_ExFlag10",SqlDbType.Text);
				p.Value = _Ezine_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_Id")))
			{
				_Ezine_Id = (System.Int32)Rd["Ezine_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_CateId")))
			{
				_Ezine_CateId = (System.Int32)Rd["Ezine_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_CateName")))
			{
				_Ezine_CateName = (System.String)Rd["Ezine_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_Title")))
			{
				_Ezine_Title = (System.String)Rd["Ezine_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_Order")))
			{
				_Ezine_Order = (System.Int32)Rd["Ezine_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_MinImage")))
			{
				_Ezine_MinImage = (System.String)Rd["Ezine_MinImage"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_BigImage")))
			{
				_Ezine_BigImage = (System.String)Rd["Ezine_BigImage"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_State")))
			{
				_Ezine_State = (System.String)Rd["Ezine_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_AddTime")))
			{
				_Ezine_AddTime = (System.DateTime)Rd["Ezine_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag1")))
			{
				_Ezine_ExFlag1 = (System.String)Rd["Ezine_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag2")))
			{
				_Ezine_ExFlag2 = (System.String)Rd["Ezine_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag3")))
			{
				_Ezine_ExFlag3 = (System.String)Rd["Ezine_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag4")))
			{
				_Ezine_ExFlag4 = (System.String)Rd["Ezine_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag5")))
			{
				_Ezine_ExFlag5 = (System.String)Rd["Ezine_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag6")))
			{
				_Ezine_ExFlag6 = (System.String)Rd["Ezine_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag7")))
			{
				_Ezine_ExFlag7 = (System.String)Rd["Ezine_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag8")))
			{
				_Ezine_ExFlag8 = (System.String)Rd["Ezine_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag9")))
			{
				_Ezine_ExFlag9 = (System.String)Rd["Ezine_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Ezine_ExFlag10")))
			{
				_Ezine_ExFlag10 = (System.String)Rd["Ezine_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Ezine();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Ezine([Ezine_CateId],[Ezine_CateName],[Ezine_Title],[Ezine_Order],[Ezine_MinImage],[Ezine_BigImage],[Ezine_State],[Ezine_AddTime],[Ezine_ExFlag1],[Ezine_ExFlag2],[Ezine_ExFlag3],[Ezine_ExFlag4],[Ezine_ExFlag5],[Ezine_ExFlag6],[Ezine_ExFlag7],[Ezine_ExFlag8],[Ezine_ExFlag9],[Ezine_ExFlag10]) VALUES (@Ezine_CateId ,@Ezine_CateName ,@Ezine_Title ,@Ezine_Order ,@Ezine_MinImage ,@Ezine_BigImage ,@Ezine_State ,@Ezine_AddTime ,@Ezine_ExFlag1 ,@Ezine_ExFlag2 ,@Ezine_ExFlag3 ,@Ezine_ExFlag4 ,@Ezine_ExFlag5 ,@Ezine_ExFlag6 ,@Ezine_ExFlag7 ,@Ezine_ExFlag8 ,@Ezine_ExFlag9 ,@Ezine_ExFlag10 )";
		}


	}

	public class Dcms_GuestBook:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "GuestBook_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_GuestBook";
		}

		private System.Int32 _GuestBook_Id;
		public System.Int32 GuestBook_Id
		{
			get{ return _GuestBook_Id; }
			set{ _GuestBook_Id = value; }
		}
		private System.Int32 _GuestBook_CateId;
		public System.Int32 GuestBook_CateId
		{
			get{ return _GuestBook_CateId; }
			set{ _GuestBook_CateId = value; }
		}
		private System.String _GuestBook_CateName;
		public System.String GuestBook_CateName
		{
			get{ return _GuestBook_CateName; }
			set{ _GuestBook_CateName = value; }
		}
		private System.String _GuestBook_Title;
		public System.String GuestBook_Title
		{
			get{ return _GuestBook_Title; }
			set{ _GuestBook_Title = value; }
		}
		private System.String _GuestBook_Content;
		public System.String GuestBook_Content
		{
			get{ return _GuestBook_Content; }
			set{ _GuestBook_Content = value; }
		}
		private System.DateTime _GuestBook_AddTime;
		public System.DateTime GuestBook_AddTime
		{
			get{ return _GuestBook_AddTime; }
			set{ _GuestBook_AddTime = value; }
		}
		private System.String _GuestBook_UserName;
		public System.String GuestBook_UserName
		{
			get{ return _GuestBook_UserName; }
			set{ _GuestBook_UserName = value; }
		}
		private System.String _GuestBook_UserIp;
		public System.String GuestBook_UserIp
		{
			get{ return _GuestBook_UserIp; }
			set{ _GuestBook_UserIp = value; }
		}
		private System.String _GuestBook_UserEmail;
		public System.String GuestBook_UserEmail
		{
			get{ return _GuestBook_UserEmail; }
			set{ _GuestBook_UserEmail = value; }
		}
		private System.String _GuestBook_UserTel;
		public System.String GuestBook_UserTel
		{
			get{ return _GuestBook_UserTel; }
			set{ _GuestBook_UserTel = value; }
		}
		private System.String _GuestBook_UserIM;
		public System.String GuestBook_UserIM
		{
			get{ return _GuestBook_UserIM; }
			set{ _GuestBook_UserIM = value; }
		}
		private System.String _GuestBook_UserPic;
		public System.String GuestBook_UserPic
		{
			get{ return _GuestBook_UserPic; }
			set{ _GuestBook_UserPic = value; }
		}
		private System.String _GuestBook_ReplyContent;
		public System.String GuestBook_ReplyContent
		{
			get{ return _GuestBook_ReplyContent; }
			set{ _GuestBook_ReplyContent = value; }
		}
		private System.DateTime _GuestBook_ReplyTime;
		public System.DateTime GuestBook_ReplyTime
		{
			get{ return _GuestBook_ReplyTime; }
			set{ _GuestBook_ReplyTime = value; }
		}
		private System.String _GuestBook_State;
		public System.String GuestBook_State
		{
			get{ return _GuestBook_State; }
			set{ _GuestBook_State = value; }
		}
		private System.String _GuestBook_SEOTitle;
		public System.String GuestBook_SEOTitle
		{
			get{ return _GuestBook_SEOTitle; }
			set{ _GuestBook_SEOTitle = value; }
		}
		private System.String _GuestBook_SEOKeyWord;
		public System.String GuestBook_SEOKeyWord
		{
			get{ return _GuestBook_SEOKeyWord; }
			set{ _GuestBook_SEOKeyWord = value; }
		}
		private System.String _GuestBook_SEODescription;
		public System.String GuestBook_SEODescription
		{
			get{ return _GuestBook_SEODescription; }
			set{ _GuestBook_SEODescription = value; }
		}
		private System.String _GuestBook_ExFlag1;
		public System.String GuestBook_ExFlag1
		{
			get{ return _GuestBook_ExFlag1; }
			set{ _GuestBook_ExFlag1 = value; }
		}
		private System.String _GuestBook_ExFlag2;
		public System.String GuestBook_ExFlag2
		{
			get{ return _GuestBook_ExFlag2; }
			set{ _GuestBook_ExFlag2 = value; }
		}
		private System.String _GuestBook_ExFlag3;
		public System.String GuestBook_ExFlag3
		{
			get{ return _GuestBook_ExFlag3; }
			set{ _GuestBook_ExFlag3 = value; }
		}
		private System.String _GuestBook_ExFlag4;
		public System.String GuestBook_ExFlag4
		{
			get{ return _GuestBook_ExFlag4; }
			set{ _GuestBook_ExFlag4 = value; }
		}
		private System.String _GuestBook_ExFlag5;
		public System.String GuestBook_ExFlag5
		{
			get{ return _GuestBook_ExFlag5; }
			set{ _GuestBook_ExFlag5 = value; }
		}
		private System.String _GuestBook_ExFlag6;
		public System.String GuestBook_ExFlag6
		{
			get{ return _GuestBook_ExFlag6; }
			set{ _GuestBook_ExFlag6 = value; }
		}
		private System.String _GuestBook_ExFlag7;
		public System.String GuestBook_ExFlag7
		{
			get{ return _GuestBook_ExFlag7; }
			set{ _GuestBook_ExFlag7 = value; }
		}
		private System.String _GuestBook_ExFlag8;
		public System.String GuestBook_ExFlag8
		{
			get{ return _GuestBook_ExFlag8; }
			set{ _GuestBook_ExFlag8 = value; }
		}
		private System.String _GuestBook_ExFlag9;
		public System.String GuestBook_ExFlag9
		{
			get{ return _GuestBook_ExFlag9; }
			set{ _GuestBook_ExFlag9 = value; }
		}
		private System.String _GuestBook_ExFlag10;
		public System.String GuestBook_ExFlag10
		{
			get{ return _GuestBook_ExFlag10; }
			set{ _GuestBook_ExFlag10 = value; }
		}


		public static Exp _GUESTBOOK_ID_ = new Exp("GuestBook_Id");
		public static Exp _GUESTBOOK_CATEID_ = new Exp("GuestBook_CateId");
		public static Exp _GUESTBOOK_CATENAME_ = new Exp("GuestBook_CateName");
		public static Exp _GUESTBOOK_TITLE_ = new Exp("GuestBook_Title");
		public static Exp _GUESTBOOK_CONTENT_ = new Exp("GuestBook_Content");
		public static Exp _GUESTBOOK_ADDTIME_ = new Exp("GuestBook_AddTime");
		public static Exp _GUESTBOOK_USERNAME_ = new Exp("GuestBook_UserName");
		public static Exp _GUESTBOOK_USERIP_ = new Exp("GuestBook_UserIp");
		public static Exp _GUESTBOOK_USEREMAIL_ = new Exp("GuestBook_UserEmail");
		public static Exp _GUESTBOOK_USERTEL_ = new Exp("GuestBook_UserTel");
		public static Exp _GUESTBOOK_USERIM_ = new Exp("GuestBook_UserIM");
		public static Exp _GUESTBOOK_USERPIC_ = new Exp("GuestBook_UserPic");
		public static Exp _GUESTBOOK_REPLYCONTENT_ = new Exp("GuestBook_ReplyContent");
		public static Exp _GUESTBOOK_REPLYTIME_ = new Exp("GuestBook_ReplyTime");
		public static Exp _GUESTBOOK_STATE_ = new Exp("GuestBook_State");
		public static Exp _GUESTBOOK_SEOTITLE_ = new Exp("GuestBook_SEOTitle");
		public static Exp _GUESTBOOK_SEOKEYWORD_ = new Exp("GuestBook_SEOKeyWord");
		public static Exp _GUESTBOOK_SEODESCRIPTION_ = new Exp("GuestBook_SEODescription");
		public static Exp _GUESTBOOK_EXFLAG1_ = new Exp("GuestBook_ExFlag1");
		public static Exp _GUESTBOOK_EXFLAG2_ = new Exp("GuestBook_ExFlag2");
		public static Exp _GUESTBOOK_EXFLAG3_ = new Exp("GuestBook_ExFlag3");
		public static Exp _GUESTBOOK_EXFLAG4_ = new Exp("GuestBook_ExFlag4");
		public static Exp _GUESTBOOK_EXFLAG5_ = new Exp("GuestBook_ExFlag5");
		public static Exp _GUESTBOOK_EXFLAG6_ = new Exp("GuestBook_ExFlag6");
		public static Exp _GUESTBOOK_EXFLAG7_ = new Exp("GuestBook_ExFlag7");
		public static Exp _GUESTBOOK_EXFLAG8_ = new Exp("GuestBook_ExFlag8");
		public static Exp _GUESTBOOK_EXFLAG9_ = new Exp("GuestBook_ExFlag9");
		public static Exp _GUESTBOOK_EXFLAG10_ = new Exp("GuestBook_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@GuestBook_Id",SqlDbType.Int);
			p.Value = _GuestBook_Id;
			rs.Add(p);
			p = new SqlParameter("@GuestBook_CateId",SqlDbType.Int);
			p.Value = _GuestBook_CateId;
			rs.Add(p);
			if (_GuestBook_CateName != null)
			{
				p = new SqlParameter("@GuestBook_CateName",SqlDbType.NVarChar);
				p.Value = _GuestBook_CateName;
				rs.Add(p);
			}
			if (_GuestBook_Title != null)
			{
				p = new SqlParameter("@GuestBook_Title",SqlDbType.NVarChar);
				p.Value = _GuestBook_Title;
				rs.Add(p);
			}
			if (_GuestBook_Content != null)
			{
				p = new SqlParameter("@GuestBook_Content",SqlDbType.NText);
				p.Value = _GuestBook_Content;
				rs.Add(p);
			}
			if (_GuestBook_AddTime != null)
			{
				if (_GuestBook_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@GuestBook_AddTime",SqlDbType.SmallDateTime);
					p.Value = _GuestBook_AddTime;
					rs.Add(p);
				}
			}
			if (_GuestBook_UserName != null)
			{
				p = new SqlParameter("@GuestBook_UserName",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserName;
				rs.Add(p);
			}
			if (_GuestBook_UserIp != null)
			{
				p = new SqlParameter("@GuestBook_UserIp",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserIp;
				rs.Add(p);
			}
			if (_GuestBook_UserEmail != null)
			{
				p = new SqlParameter("@GuestBook_UserEmail",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserEmail;
				rs.Add(p);
			}
			if (_GuestBook_UserTel != null)
			{
				p = new SqlParameter("@GuestBook_UserTel",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserTel;
				rs.Add(p);
			}
			if (_GuestBook_UserIM != null)
			{
				p = new SqlParameter("@GuestBook_UserIM",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserIM;
				rs.Add(p);
			}
			if (_GuestBook_UserPic != null)
			{
				p = new SqlParameter("@GuestBook_UserPic",SqlDbType.NVarChar);
				p.Value = _GuestBook_UserPic;
				rs.Add(p);
			}
			if (_GuestBook_ReplyContent != null)
			{
				p = new SqlParameter("@GuestBook_ReplyContent",SqlDbType.NText);
				p.Value = _GuestBook_ReplyContent;
				rs.Add(p);
			}
			if (_GuestBook_ReplyTime != null)
			{
				if (_GuestBook_ReplyTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@GuestBook_ReplyTime",SqlDbType.SmallDateTime);
					p.Value = _GuestBook_ReplyTime;
					rs.Add(p);
				}
			}
			if (_GuestBook_State != null)
			{
				p = new SqlParameter("@GuestBook_State",SqlDbType.NVarChar);
				p.Value = _GuestBook_State;
				rs.Add(p);
			}
			if (_GuestBook_SEOTitle != null)
			{
				p = new SqlParameter("@GuestBook_SEOTitle",SqlDbType.NVarChar);
				p.Value = _GuestBook_SEOTitle;
				rs.Add(p);
			}
			if (_GuestBook_SEOKeyWord != null)
			{
				p = new SqlParameter("@GuestBook_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _GuestBook_SEOKeyWord;
				rs.Add(p);
			}
			if (_GuestBook_SEODescription != null)
			{
				p = new SqlParameter("@GuestBook_SEODescription",SqlDbType.NVarChar);
				p.Value = _GuestBook_SEODescription;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag1 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag1",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag1;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag2 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag2",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag2;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag3 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag3",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag3;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag4 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag4",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag4;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag5 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag5",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag5;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag6 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag6",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag6;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag7 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag7",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag7;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag8 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag8",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag8;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag9 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag9",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag9;
				rs.Add(p);
			}
			if (_GuestBook_ExFlag10 != null)
			{
				p = new SqlParameter("@GuestBook_ExFlag10",SqlDbType.NText);
				p.Value = _GuestBook_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_Id")))
			{
				_GuestBook_Id = (System.Int32)Rd["GuestBook_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_CateId")))
			{
				_GuestBook_CateId = (System.Int32)Rd["GuestBook_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_CateName")))
			{
				_GuestBook_CateName = (System.String)Rd["GuestBook_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_Title")))
			{
				_GuestBook_Title = (System.String)Rd["GuestBook_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_Content")))
			{
				_GuestBook_Content = (System.String)Rd["GuestBook_Content"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_AddTime")))
			{
				_GuestBook_AddTime = (System.DateTime)Rd["GuestBook_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserName")))
			{
				_GuestBook_UserName = (System.String)Rd["GuestBook_UserName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserIp")))
			{
				_GuestBook_UserIp = (System.String)Rd["GuestBook_UserIp"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserEmail")))
			{
				_GuestBook_UserEmail = (System.String)Rd["GuestBook_UserEmail"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserTel")))
			{
				_GuestBook_UserTel = (System.String)Rd["GuestBook_UserTel"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserIM")))
			{
				_GuestBook_UserIM = (System.String)Rd["GuestBook_UserIM"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_UserPic")))
			{
				_GuestBook_UserPic = (System.String)Rd["GuestBook_UserPic"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ReplyContent")))
			{
				_GuestBook_ReplyContent = (System.String)Rd["GuestBook_ReplyContent"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ReplyTime")))
			{
				_GuestBook_ReplyTime = (System.DateTime)Rd["GuestBook_ReplyTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_State")))
			{
				_GuestBook_State = (System.String)Rd["GuestBook_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_SEOTitle")))
			{
				_GuestBook_SEOTitle = (System.String)Rd["GuestBook_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_SEOKeyWord")))
			{
				_GuestBook_SEOKeyWord = (System.String)Rd["GuestBook_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_SEODescription")))
			{
				_GuestBook_SEODescription = (System.String)Rd["GuestBook_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag1")))
			{
				_GuestBook_ExFlag1 = (System.String)Rd["GuestBook_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag2")))
			{
				_GuestBook_ExFlag2 = (System.String)Rd["GuestBook_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag3")))
			{
				_GuestBook_ExFlag3 = (System.String)Rd["GuestBook_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag4")))
			{
				_GuestBook_ExFlag4 = (System.String)Rd["GuestBook_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag5")))
			{
				_GuestBook_ExFlag5 = (System.String)Rd["GuestBook_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag6")))
			{
				_GuestBook_ExFlag6 = (System.String)Rd["GuestBook_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag7")))
			{
				_GuestBook_ExFlag7 = (System.String)Rd["GuestBook_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag8")))
			{
				_GuestBook_ExFlag8 = (System.String)Rd["GuestBook_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag9")))
			{
				_GuestBook_ExFlag9 = (System.String)Rd["GuestBook_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("GuestBook_ExFlag10")))
			{
				_GuestBook_ExFlag10 = (System.String)Rd["GuestBook_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_GuestBook();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_GuestBook([GuestBook_CateId],[GuestBook_CateName],[GuestBook_Title],[GuestBook_Content],[GuestBook_AddTime],[GuestBook_UserName],[GuestBook_UserIp],[GuestBook_UserEmail],[GuestBook_UserTel],[GuestBook_UserIM],[GuestBook_UserPic],[GuestBook_ReplyContent],[GuestBook_ReplyTime],[GuestBook_State],[GuestBook_SEOTitle],[GuestBook_SEOKeyWord],[GuestBook_SEODescription],[GuestBook_ExFlag1],[GuestBook_ExFlag2],[GuestBook_ExFlag3],[GuestBook_ExFlag4],[GuestBook_ExFlag5],[GuestBook_ExFlag6],[GuestBook_ExFlag7],[GuestBook_ExFlag8],[GuestBook_ExFlag9],[GuestBook_ExFlag10]) VALUES (@GuestBook_CateId ,@GuestBook_CateName ,@GuestBook_Title ,@GuestBook_Content ,@GuestBook_AddTime ,@GuestBook_UserName ,@GuestBook_UserIp ,@GuestBook_UserEmail ,@GuestBook_UserTel ,@GuestBook_UserIM ,@GuestBook_UserPic ,@GuestBook_ReplyContent ,@GuestBook_ReplyTime ,@GuestBook_State ,@GuestBook_SEOTitle ,@GuestBook_SEOKeyWord ,@GuestBook_SEODescription ,@GuestBook_ExFlag1 ,@GuestBook_ExFlag2 ,@GuestBook_ExFlag3 ,@GuestBook_ExFlag4 ,@GuestBook_ExFlag5 ,@GuestBook_ExFlag6 ,@GuestBook_ExFlag7 ,@GuestBook_ExFlag8 ,@GuestBook_ExFlag9 ,@GuestBook_ExFlag10 )";
		}


	}

	public class Dcms_JobSeeker:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Js_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_JobSeeker";
		}

		private System.Int32 _Js_Id;
		public System.Int32 Js_Id
		{
			get{ return _Js_Id; }
			set{ _Js_Id = value; }
		}
		private System.Int32 _Js_PId;
		public System.Int32 Js_PId
		{
			get{ return _Js_PId; }
			set{ _Js_PId = value; }
		}
		private System.String _Js_PName;
		public System.String Js_PName
		{
			get{ return _Js_PName; }
			set{ _Js_PName = value; }
		}
		private System.String _Js_IdentityType;
		public System.String Js_IdentityType
		{
			get{ return _Js_IdentityType; }
			set{ _Js_IdentityType = value; }
		}
		private System.String _Js_Identity;
		public System.String Js_Identity
		{
			get{ return _Js_Identity; }
			set{ _Js_Identity = value; }
		}
		private System.String _Js_Password;
		public System.String Js_Password
		{
			get{ return _Js_Password; }
			set{ _Js_Password = value; }
		}
		private System.String _Js_RealName;
		public System.String Js_RealName
		{
			get{ return _Js_RealName; }
			set{ _Js_RealName = value; }
		}
		private System.String _Js_Sex;
		public System.String Js_Sex
		{
			get{ return _Js_Sex; }
			set{ _Js_Sex = value; }
		}
		private System.String _Js_Address;
		public System.String Js_Address
		{
			get{ return _Js_Address; }
			set{ _Js_Address = value; }
		}
		private System.String _Js_Marry;
		public System.String Js_Marry
		{
			get{ return _Js_Marry; }
			set{ _Js_Marry = value; }
		}
		private System.DateTime _Js_Birth;
		public System.DateTime Js_Birth
		{
			get{ return _Js_Birth; }
			set{ _Js_Birth = value; }
		}
		private System.String _Js_Tel;
		public System.String Js_Tel
		{
			get{ return _Js_Tel; }
			set{ _Js_Tel = value; }
		}
		private System.String _Js_National;
		public System.String Js_National
		{
			get{ return _Js_National; }
			set{ _Js_National = value; }
		}
		private System.String _Js_FamilyTel;
		public System.String Js_FamilyTel
		{
			get{ return _Js_FamilyTel; }
			set{ _Js_FamilyTel = value; }
		}
		private System.String _Js_Email;
		public System.String Js_Email
		{
			get{ return _Js_Email; }
			set{ _Js_Email = value; }
		}
		private System.String _Js_FirstContacter;
		public System.String Js_FirstContacter
		{
			get{ return _Js_FirstContacter; }
			set{ _Js_FirstContacter = value; }
		}
		private System.String _Js_FirstContacterTel;
		public System.String Js_FirstContacterTel
		{
			get{ return _Js_FirstContacterTel; }
			set{ _Js_FirstContacterTel = value; }
		}
		private System.String _Js_WorkTime;
		public System.String Js_WorkTime
		{
			get{ return _Js_WorkTime; }
			set{ _Js_WorkTime = value; }
		}
		private System.String _Js_ForeignLanguage;
		public System.String Js_ForeignLanguage
		{
			get{ return _Js_ForeignLanguage; }
			set{ _Js_ForeignLanguage = value; }
		}
		private System.String _Js_Computer;
		public System.String Js_Computer
		{
			get{ return _Js_Computer; }
			set{ _Js_Computer = value; }
		}
		private System.String _Js_WorkPlace;
		public System.String Js_WorkPlace
		{
			get{ return _Js_WorkPlace; }
			set{ _Js_WorkPlace = value; }
		}
		private System.String _Js_PayDemands;
		public System.String Js_PayDemands
		{
			get{ return _Js_PayDemands; }
			set{ _Js_PayDemands = value; }
		}
		private System.String _Js_AboutEdu;
		public System.String Js_AboutEdu
		{
			get{ return _Js_AboutEdu; }
			set{ _Js_AboutEdu = value; }
		}
		private System.String _Js_AboutWork;
		public System.String Js_AboutWork
		{
			get{ return _Js_AboutWork; }
			set{ _Js_AboutWork = value; }
		}
		private System.String _Js_AboutTrain;
		public System.String Js_AboutTrain
		{
			get{ return _Js_AboutTrain; }
			set{ _Js_AboutTrain = value; }
		}
		private System.String _Js_AboutFamily;
		public System.String Js_AboutFamily
		{
			get{ return _Js_AboutFamily; }
			set{ _Js_AboutFamily = value; }
		}
		private System.String _Js_AboutMe;
		public System.String Js_AboutMe
		{
			get{ return _Js_AboutMe; }
			set{ _Js_AboutMe = value; }
		}
		private System.DateTime _Js_AddTime;
		public System.DateTime Js_AddTime
		{
			get{ return _Js_AddTime; }
			set{ _Js_AddTime = value; }
		}
		private System.String _Js_HighEdu;
		public System.String Js_HighEdu
		{
			get{ return _Js_HighEdu; }
			set{ _Js_HighEdu = value; }
		}
		private System.String _Js_ExFlag1;
		public System.String Js_ExFlag1
		{
			get{ return _Js_ExFlag1; }
			set{ _Js_ExFlag1 = value; }
		}
		private System.String _Js_ExFlag2;
		public System.String Js_ExFlag2
		{
			get{ return _Js_ExFlag2; }
			set{ _Js_ExFlag2 = value; }
		}
		private System.String _Js_ExFlag3;
		public System.String Js_ExFlag3
		{
			get{ return _Js_ExFlag3; }
			set{ _Js_ExFlag3 = value; }
		}
		private System.String _Js_ExFlag4;
		public System.String Js_ExFlag4
		{
			get{ return _Js_ExFlag4; }
			set{ _Js_ExFlag4 = value; }
		}
		private System.String _Js_ExFlag5;
		public System.String Js_ExFlag5
		{
			get{ return _Js_ExFlag5; }
			set{ _Js_ExFlag5 = value; }
		}


		public static Exp _JS_ID_ = new Exp("Js_Id");
		public static Exp _JS_PID_ = new Exp("Js_PId");
		public static Exp _JS_PNAME_ = new Exp("Js_PName");
		public static Exp _JS_IDENTITYTYPE_ = new Exp("Js_IdentityType");
		public static Exp _JS_IDENTITY_ = new Exp("Js_Identity");
		public static Exp _JS_PASSWORD_ = new Exp("Js_Password");
		public static Exp _JS_REALNAME_ = new Exp("Js_RealName");
		public static Exp _JS_SEX_ = new Exp("Js_Sex");
		public static Exp _JS_ADDRESS_ = new Exp("Js_Address");
		public static Exp _JS_MARRY_ = new Exp("Js_Marry");
		public static Exp _JS_BIRTH_ = new Exp("Js_Birth");
		public static Exp _JS_TEL_ = new Exp("Js_Tel");
		public static Exp _JS_NATIONAL_ = new Exp("Js_National");
		public static Exp _JS_FAMILYTEL_ = new Exp("Js_FamilyTel");
		public static Exp _JS_EMAIL_ = new Exp("Js_Email");
		public static Exp _JS_FIRSTCONTACTER_ = new Exp("Js_FirstContacter");
		public static Exp _JS_FIRSTCONTACTERTEL_ = new Exp("Js_FirstContacterTel");
		public static Exp _JS_WORKTIME_ = new Exp("Js_WorkTime");
		public static Exp _JS_FOREIGNLANGUAGE_ = new Exp("Js_ForeignLanguage");
		public static Exp _JS_COMPUTER_ = new Exp("Js_Computer");
		public static Exp _JS_WORKPLACE_ = new Exp("Js_WorkPlace");
		public static Exp _JS_PAYDEMANDS_ = new Exp("Js_PayDemands");
		public static Exp _JS_ABOUTEDU_ = new Exp("Js_AboutEdu");
		public static Exp _JS_ABOUTWORK_ = new Exp("Js_AboutWork");
		public static Exp _JS_ABOUTTRAIN_ = new Exp("Js_AboutTrain");
		public static Exp _JS_ABOUTFAMILY_ = new Exp("Js_AboutFamily");
		public static Exp _JS_ABOUTME_ = new Exp("Js_AboutMe");
		public static Exp _JS_ADDTIME_ = new Exp("Js_AddTime");
		public static Exp _JS_HIGHEDU_ = new Exp("Js_HighEdu");
		public static Exp _JS_EXFLAG1_ = new Exp("Js_ExFlag1");
		public static Exp _JS_EXFLAG2_ = new Exp("Js_ExFlag2");
		public static Exp _JS_EXFLAG3_ = new Exp("Js_ExFlag3");
		public static Exp _JS_EXFLAG4_ = new Exp("Js_ExFlag4");
		public static Exp _JS_EXFLAG5_ = new Exp("Js_ExFlag5");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Js_Id",SqlDbType.Int);
			p.Value = _Js_Id;
			rs.Add(p);
			p = new SqlParameter("@Js_PId",SqlDbType.Int);
			p.Value = _Js_PId;
			rs.Add(p);
			if (_Js_PName != null)
			{
				p = new SqlParameter("@Js_PName",SqlDbType.VarChar);
				p.Value = _Js_PName;
				rs.Add(p);
			}
			if (_Js_IdentityType != null)
			{
				p = new SqlParameter("@Js_IdentityType",SqlDbType.VarChar);
				p.Value = _Js_IdentityType;
				rs.Add(p);
			}
			if (_Js_Identity != null)
			{
				p = new SqlParameter("@Js_Identity",SqlDbType.VarChar);
				p.Value = _Js_Identity;
				rs.Add(p);
			}
			if (_Js_Password != null)
			{
				p = new SqlParameter("@Js_Password",SqlDbType.VarChar);
				p.Value = _Js_Password;
				rs.Add(p);
			}
			if (_Js_RealName != null)
			{
				p = new SqlParameter("@Js_RealName",SqlDbType.VarChar);
				p.Value = _Js_RealName;
				rs.Add(p);
			}
			if (_Js_Sex != null)
			{
				p = new SqlParameter("@Js_Sex",SqlDbType.VarChar);
				p.Value = _Js_Sex;
				rs.Add(p);
			}
			if (_Js_Address != null)
			{
				p = new SqlParameter("@Js_Address",SqlDbType.VarChar);
				p.Value = _Js_Address;
				rs.Add(p);
			}
			if (_Js_Marry != null)
			{
				p = new SqlParameter("@Js_Marry",SqlDbType.VarChar);
				p.Value = _Js_Marry;
				rs.Add(p);
			}
			if (_Js_Birth != null)
			{
				if (_Js_Birth.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Js_Birth",SqlDbType.DateTime);
					p.Value = _Js_Birth;
					rs.Add(p);
				}
			}
			if (_Js_Tel != null)
			{
				p = new SqlParameter("@Js_Tel",SqlDbType.VarChar);
				p.Value = _Js_Tel;
				rs.Add(p);
			}
			if (_Js_National != null)
			{
				p = new SqlParameter("@Js_National",SqlDbType.VarChar);
				p.Value = _Js_National;
				rs.Add(p);
			}
			if (_Js_FamilyTel != null)
			{
				p = new SqlParameter("@Js_FamilyTel",SqlDbType.VarChar);
				p.Value = _Js_FamilyTel;
				rs.Add(p);
			}
			if (_Js_Email != null)
			{
				p = new SqlParameter("@Js_Email",SqlDbType.VarChar);
				p.Value = _Js_Email;
				rs.Add(p);
			}
			if (_Js_FirstContacter != null)
			{
				p = new SqlParameter("@Js_FirstContacter",SqlDbType.VarChar);
				p.Value = _Js_FirstContacter;
				rs.Add(p);
			}
			if (_Js_FirstContacterTel != null)
			{
				p = new SqlParameter("@Js_FirstContacterTel",SqlDbType.VarChar);
				p.Value = _Js_FirstContacterTel;
				rs.Add(p);
			}
			if (_Js_WorkTime != null)
			{
				p = new SqlParameter("@Js_WorkTime",SqlDbType.VarChar);
				p.Value = _Js_WorkTime;
				rs.Add(p);
			}
			if (_Js_ForeignLanguage != null)
			{
				p = new SqlParameter("@Js_ForeignLanguage",SqlDbType.VarChar);
				p.Value = _Js_ForeignLanguage;
				rs.Add(p);
			}
			if (_Js_Computer != null)
			{
				p = new SqlParameter("@Js_Computer",SqlDbType.VarChar);
				p.Value = _Js_Computer;
				rs.Add(p);
			}
			if (_Js_WorkPlace != null)
			{
				p = new SqlParameter("@Js_WorkPlace",SqlDbType.VarChar);
				p.Value = _Js_WorkPlace;
				rs.Add(p);
			}
			if (_Js_PayDemands != null)
			{
				p = new SqlParameter("@Js_PayDemands",SqlDbType.VarChar);
				p.Value = _Js_PayDemands;
				rs.Add(p);
			}
			if (_Js_AboutEdu != null)
			{
				p = new SqlParameter("@Js_AboutEdu",SqlDbType.Text);
				p.Value = _Js_AboutEdu;
				rs.Add(p);
			}
			if (_Js_AboutWork != null)
			{
				p = new SqlParameter("@Js_AboutWork",SqlDbType.Text);
				p.Value = _Js_AboutWork;
				rs.Add(p);
			}
			if (_Js_AboutTrain != null)
			{
				p = new SqlParameter("@Js_AboutTrain",SqlDbType.Text);
				p.Value = _Js_AboutTrain;
				rs.Add(p);
			}
			if (_Js_AboutFamily != null)
			{
				p = new SqlParameter("@Js_AboutFamily",SqlDbType.Text);
				p.Value = _Js_AboutFamily;
				rs.Add(p);
			}
			if (_Js_AboutMe != null)
			{
				p = new SqlParameter("@Js_AboutMe",SqlDbType.Text);
				p.Value = _Js_AboutMe;
				rs.Add(p);
			}
			if (_Js_AddTime != null)
			{
				if (_Js_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Js_AddTime",SqlDbType.DateTime);
					p.Value = _Js_AddTime;
					rs.Add(p);
				}
			}
			if (_Js_HighEdu != null)
			{
				p = new SqlParameter("@Js_HighEdu",SqlDbType.VarChar);
				p.Value = _Js_HighEdu;
				rs.Add(p);
			}
			if (_Js_ExFlag1 != null)
			{
				p = new SqlParameter("@Js_ExFlag1",SqlDbType.NText);
				p.Value = _Js_ExFlag1;
				rs.Add(p);
			}
			if (_Js_ExFlag2 != null)
			{
				p = new SqlParameter("@Js_ExFlag2",SqlDbType.NText);
				p.Value = _Js_ExFlag2;
				rs.Add(p);
			}
			if (_Js_ExFlag3 != null)
			{
				p = new SqlParameter("@Js_ExFlag3",SqlDbType.NText);
				p.Value = _Js_ExFlag3;
				rs.Add(p);
			}
			if (_Js_ExFlag4 != null)
			{
				p = new SqlParameter("@Js_ExFlag4",SqlDbType.NText);
				p.Value = _Js_ExFlag4;
				rs.Add(p);
			}
			if (_Js_ExFlag5 != null)
			{
				p = new SqlParameter("@Js_ExFlag5",SqlDbType.NText);
				p.Value = _Js_ExFlag5;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Id")))
			{
				_Js_Id = (System.Int32)Rd["Js_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_PId")))
			{
				_Js_PId = (System.Int32)Rd["Js_PId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_PName")))
			{
				_Js_PName = (System.String)Rd["Js_PName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_IdentityType")))
			{
				_Js_IdentityType = (System.String)Rd["Js_IdentityType"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Identity")))
			{
				_Js_Identity = (System.String)Rd["Js_Identity"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Password")))
			{
				_Js_Password = (System.String)Rd["Js_Password"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_RealName")))
			{
				_Js_RealName = (System.String)Rd["Js_RealName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Sex")))
			{
				_Js_Sex = (System.String)Rd["Js_Sex"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Address")))
			{
				_Js_Address = (System.String)Rd["Js_Address"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Marry")))
			{
				_Js_Marry = (System.String)Rd["Js_Marry"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Birth")))
			{
				_Js_Birth = (System.DateTime)Rd["Js_Birth"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Tel")))
			{
				_Js_Tel = (System.String)Rd["Js_Tel"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_National")))
			{
				_Js_National = (System.String)Rd["Js_National"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_FamilyTel")))
			{
				_Js_FamilyTel = (System.String)Rd["Js_FamilyTel"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Email")))
			{
				_Js_Email = (System.String)Rd["Js_Email"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_FirstContacter")))
			{
				_Js_FirstContacter = (System.String)Rd["Js_FirstContacter"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_FirstContacterTel")))
			{
				_Js_FirstContacterTel = (System.String)Rd["Js_FirstContacterTel"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_WorkTime")))
			{
				_Js_WorkTime = (System.String)Rd["Js_WorkTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ForeignLanguage")))
			{
				_Js_ForeignLanguage = (System.String)Rd["Js_ForeignLanguage"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_Computer")))
			{
				_Js_Computer = (System.String)Rd["Js_Computer"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_WorkPlace")))
			{
				_Js_WorkPlace = (System.String)Rd["Js_WorkPlace"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_PayDemands")))
			{
				_Js_PayDemands = (System.String)Rd["Js_PayDemands"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AboutEdu")))
			{
				_Js_AboutEdu = (System.String)Rd["Js_AboutEdu"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AboutWork")))
			{
				_Js_AboutWork = (System.String)Rd["Js_AboutWork"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AboutTrain")))
			{
				_Js_AboutTrain = (System.String)Rd["Js_AboutTrain"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AboutFamily")))
			{
				_Js_AboutFamily = (System.String)Rd["Js_AboutFamily"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AboutMe")))
			{
				_Js_AboutMe = (System.String)Rd["Js_AboutMe"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_AddTime")))
			{
				_Js_AddTime = (System.DateTime)Rd["Js_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_HighEdu")))
			{
				_Js_HighEdu = (System.String)Rd["Js_HighEdu"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ExFlag1")))
			{
				_Js_ExFlag1 = (System.String)Rd["Js_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ExFlag2")))
			{
				_Js_ExFlag2 = (System.String)Rd["Js_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ExFlag3")))
			{
				_Js_ExFlag3 = (System.String)Rd["Js_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ExFlag4")))
			{
				_Js_ExFlag4 = (System.String)Rd["Js_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Js_ExFlag5")))
			{
				_Js_ExFlag5 = (System.String)Rd["Js_ExFlag5"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_JobSeeker();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_JobSeeker([Js_PId],[Js_PName],[Js_IdentityType],[Js_Identity],[Js_Password],[Js_RealName],[Js_Sex],[Js_Address],[Js_Marry],[Js_Birth],[Js_Tel],[Js_National],[Js_FamilyTel],[Js_Email],[Js_FirstContacter],[Js_FirstContacterTel],[Js_WorkTime],[Js_ForeignLanguage],[Js_Computer],[Js_WorkPlace],[Js_PayDemands],[Js_AboutEdu],[Js_AboutWork],[Js_AboutTrain],[Js_AboutFamily],[Js_AboutMe],[Js_AddTime],[Js_HighEdu],[Js_ExFlag1],[Js_ExFlag2],[Js_ExFlag3],[Js_ExFlag4],[Js_ExFlag5]) VALUES (@Js_PId ,@Js_PName ,@Js_IdentityType ,@Js_Identity ,@Js_Password ,@Js_RealName ,@Js_Sex ,@Js_Address ,@Js_Marry ,@Js_Birth ,@Js_Tel ,@Js_National ,@Js_FamilyTel ,@Js_Email ,@Js_FirstContacter ,@Js_FirstContacterTel ,@Js_WorkTime ,@Js_ForeignLanguage ,@Js_Computer ,@Js_WorkPlace ,@Js_PayDemands ,@Js_AboutEdu ,@Js_AboutWork ,@Js_AboutTrain ,@Js_AboutFamily ,@Js_AboutMe ,@Js_AddTime ,@Js_HighEdu ,@Js_ExFlag1 ,@Js_ExFlag2 ,@Js_ExFlag3 ,@Js_ExFlag4 ,@Js_ExFlag5 )";
		}


	}

	public class Dcms_Link:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Link_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Link";
		}

		private System.Int32 _Link_Id;
		public System.Int32 Link_Id
		{
			get{ return _Link_Id; }
			set{ _Link_Id = value; }
		}
		private System.Int32 _Link_CateId;
		public System.Int32 Link_CateId
		{
			get{ return _Link_CateId; }
			set{ _Link_CateId = value; }
		}
		private System.String _Link_CateName;
		public System.String Link_CateName
		{
			get{ return _Link_CateName; }
			set{ _Link_CateName = value; }
		}
		private System.String _Link_Title;
		public System.String Link_Title
		{
			get{ return _Link_Title; }
			set{ _Link_Title = value; }
		}
		private System.String _Link_Url;
		public System.String Link_Url
		{
			get{ return _Link_Url; }
			set{ _Link_Url = value; }
		}
		private System.String _Link_Pic;
		public System.String Link_Pic
		{
			get{ return _Link_Pic; }
			set{ _Link_Pic = value; }
		}
		private System.String _Link_Intro;
		public System.String Link_Intro
		{
			get{ return _Link_Intro; }
			set{ _Link_Intro = value; }
		}
		private System.DateTime _Link_AddTime;
		public System.DateTime Link_AddTime
		{
			get{ return _Link_AddTime; }
			set{ _Link_AddTime = value; }
		}
		private System.String _Link_State;
		public System.String Link_State
		{
			get{ return _Link_State; }
			set{ _Link_State = value; }
		}
		private System.Int32 _Link_Order;
		public System.Int32 Link_Order
		{
			get{ return _Link_Order; }
			set{ _Link_Order = value; }
		}
		private System.String _Link_SEOTitle;
		public System.String Link_SEOTitle
		{
			get{ return _Link_SEOTitle; }
			set{ _Link_SEOTitle = value; }
		}
		private System.String _Link_SEOKeyWord;
		public System.String Link_SEOKeyWord
		{
			get{ return _Link_SEOKeyWord; }
			set{ _Link_SEOKeyWord = value; }
		}
		private System.String _Link_SEODescription;
		public System.String Link_SEODescription
		{
			get{ return _Link_SEODescription; }
			set{ _Link_SEODescription = value; }
		}
		private System.String _Link_ExFlag1;
		public System.String Link_ExFlag1
		{
			get{ return _Link_ExFlag1; }
			set{ _Link_ExFlag1 = value; }
		}
		private System.String _Link_ExFlag2;
		public System.String Link_ExFlag2
		{
			get{ return _Link_ExFlag2; }
			set{ _Link_ExFlag2 = value; }
		}
		private System.String _Link_ExFlag3;
		public System.String Link_ExFlag3
		{
			get{ return _Link_ExFlag3; }
			set{ _Link_ExFlag3 = value; }
		}
		private System.String _Link_ExFlag4;
		public System.String Link_ExFlag4
		{
			get{ return _Link_ExFlag4; }
			set{ _Link_ExFlag4 = value; }
		}
		private System.String _Link_ExFlag5;
		public System.String Link_ExFlag5
		{
			get{ return _Link_ExFlag5; }
			set{ _Link_ExFlag5 = value; }
		}
		private System.String _Link_ExFlag6;
		public System.String Link_ExFlag6
		{
			get{ return _Link_ExFlag6; }
			set{ _Link_ExFlag6 = value; }
		}
		private System.String _Link_ExFlag7;
		public System.String Link_ExFlag7
		{
			get{ return _Link_ExFlag7; }
			set{ _Link_ExFlag7 = value; }
		}
		private System.String _Link_ExFlag8;
		public System.String Link_ExFlag8
		{
			get{ return _Link_ExFlag8; }
			set{ _Link_ExFlag8 = value; }
		}
		private System.String _Link_ExFlag9;
		public System.String Link_ExFlag9
		{
			get{ return _Link_ExFlag9; }
			set{ _Link_ExFlag9 = value; }
		}
		private System.String _Link_ExFlag10;
		public System.String Link_ExFlag10
		{
			get{ return _Link_ExFlag10; }
			set{ _Link_ExFlag10 = value; }
		}


		public static Exp _LINK_ID_ = new Exp("Link_Id");
		public static Exp _LINK_CATEID_ = new Exp("Link_CateId");
		public static Exp _LINK_CATENAME_ = new Exp("Link_CateName");
		public static Exp _LINK_TITLE_ = new Exp("Link_Title");
		public static Exp _LINK_URL_ = new Exp("Link_Url");
		public static Exp _LINK_PIC_ = new Exp("Link_Pic");
		public static Exp _LINK_INTRO_ = new Exp("Link_Intro");
		public static Exp _LINK_ADDTIME_ = new Exp("Link_AddTime");
		public static Exp _LINK_STATE_ = new Exp("Link_State");
		public static Exp _LINK_ORDER_ = new Exp("Link_Order");
		public static Exp _LINK_SEOTITLE_ = new Exp("Link_SEOTitle");
		public static Exp _LINK_SEOKEYWORD_ = new Exp("Link_SEOKeyWord");
		public static Exp _LINK_SEODESCRIPTION_ = new Exp("Link_SEODescription");
		public static Exp _LINK_EXFLAG1_ = new Exp("Link_ExFlag1");
		public static Exp _LINK_EXFLAG2_ = new Exp("Link_ExFlag2");
		public static Exp _LINK_EXFLAG3_ = new Exp("Link_ExFlag3");
		public static Exp _LINK_EXFLAG4_ = new Exp("Link_ExFlag4");
		public static Exp _LINK_EXFLAG5_ = new Exp("Link_ExFlag5");
		public static Exp _LINK_EXFLAG6_ = new Exp("Link_ExFlag6");
		public static Exp _LINK_EXFLAG7_ = new Exp("Link_ExFlag7");
		public static Exp _LINK_EXFLAG8_ = new Exp("Link_ExFlag8");
		public static Exp _LINK_EXFLAG9_ = new Exp("Link_ExFlag9");
		public static Exp _LINK_EXFLAG10_ = new Exp("Link_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Link_Id",SqlDbType.Int);
			p.Value = _Link_Id;
			rs.Add(p);
			p = new SqlParameter("@Link_CateId",SqlDbType.Int);
			p.Value = _Link_CateId;
			rs.Add(p);
			if (_Link_CateName != null)
			{
				p = new SqlParameter("@Link_CateName",SqlDbType.NVarChar);
				p.Value = _Link_CateName;
				rs.Add(p);
			}
			if (_Link_Title != null)
			{
				p = new SqlParameter("@Link_Title",SqlDbType.NVarChar);
				p.Value = _Link_Title;
				rs.Add(p);
			}
			if (_Link_Url != null)
			{
				p = new SqlParameter("@Link_Url",SqlDbType.NVarChar);
				p.Value = _Link_Url;
				rs.Add(p);
			}
			if (_Link_Pic != null)
			{
				p = new SqlParameter("@Link_Pic",SqlDbType.NVarChar);
				p.Value = _Link_Pic;
				rs.Add(p);
			}
			if (_Link_Intro != null)
			{
				p = new SqlParameter("@Link_Intro",SqlDbType.NText);
				p.Value = _Link_Intro;
				rs.Add(p);
			}
			if (_Link_AddTime != null)
			{
				if (_Link_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Link_AddTime",SqlDbType.SmallDateTime);
					p.Value = _Link_AddTime;
					rs.Add(p);
				}
			}
			if (_Link_State != null)
			{
				p = new SqlParameter("@Link_State",SqlDbType.NVarChar);
				p.Value = _Link_State;
				rs.Add(p);
			}
			p = new SqlParameter("@Link_Order",SqlDbType.Int);
			p.Value = _Link_Order;
			rs.Add(p);
			if (_Link_SEOTitle != null)
			{
				p = new SqlParameter("@Link_SEOTitle",SqlDbType.NVarChar);
				p.Value = _Link_SEOTitle;
				rs.Add(p);
			}
			if (_Link_SEOKeyWord != null)
			{
				p = new SqlParameter("@Link_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _Link_SEOKeyWord;
				rs.Add(p);
			}
			if (_Link_SEODescription != null)
			{
				p = new SqlParameter("@Link_SEODescription",SqlDbType.NVarChar);
				p.Value = _Link_SEODescription;
				rs.Add(p);
			}
			if (_Link_ExFlag1 != null)
			{
				p = new SqlParameter("@Link_ExFlag1",SqlDbType.NText);
				p.Value = _Link_ExFlag1;
				rs.Add(p);
			}
			if (_Link_ExFlag2 != null)
			{
				p = new SqlParameter("@Link_ExFlag2",SqlDbType.NText);
				p.Value = _Link_ExFlag2;
				rs.Add(p);
			}
			if (_Link_ExFlag3 != null)
			{
				p = new SqlParameter("@Link_ExFlag3",SqlDbType.NText);
				p.Value = _Link_ExFlag3;
				rs.Add(p);
			}
			if (_Link_ExFlag4 != null)
			{
				p = new SqlParameter("@Link_ExFlag4",SqlDbType.NText);
				p.Value = _Link_ExFlag4;
				rs.Add(p);
			}
			if (_Link_ExFlag5 != null)
			{
				p = new SqlParameter("@Link_ExFlag5",SqlDbType.NText);
				p.Value = _Link_ExFlag5;
				rs.Add(p);
			}
			if (_Link_ExFlag6 != null)
			{
				p = new SqlParameter("@Link_ExFlag6",SqlDbType.NText);
				p.Value = _Link_ExFlag6;
				rs.Add(p);
			}
			if (_Link_ExFlag7 != null)
			{
				p = new SqlParameter("@Link_ExFlag7",SqlDbType.NText);
				p.Value = _Link_ExFlag7;
				rs.Add(p);
			}
			if (_Link_ExFlag8 != null)
			{
				p = new SqlParameter("@Link_ExFlag8",SqlDbType.NText);
				p.Value = _Link_ExFlag8;
				rs.Add(p);
			}
			if (_Link_ExFlag9 != null)
			{
				p = new SqlParameter("@Link_ExFlag9",SqlDbType.NText);
				p.Value = _Link_ExFlag9;
				rs.Add(p);
			}
			if (_Link_ExFlag10 != null)
			{
				p = new SqlParameter("@Link_ExFlag10",SqlDbType.NText);
				p.Value = _Link_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Id")))
			{
				_Link_Id = (System.Int32)Rd["Link_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_CateId")))
			{
				_Link_CateId = (System.Int32)Rd["Link_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_CateName")))
			{
				_Link_CateName = (System.String)Rd["Link_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Title")))
			{
				_Link_Title = (System.String)Rd["Link_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Url")))
			{
				_Link_Url = (System.String)Rd["Link_Url"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Pic")))
			{
				_Link_Pic = (System.String)Rd["Link_Pic"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Intro")))
			{
				_Link_Intro = (System.String)Rd["Link_Intro"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_AddTime")))
			{
				_Link_AddTime = (System.DateTime)Rd["Link_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_State")))
			{
				_Link_State = (System.String)Rd["Link_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_Order")))
			{
				_Link_Order = (System.Int32)Rd["Link_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_SEOTitle")))
			{
				_Link_SEOTitle = (System.String)Rd["Link_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_SEOKeyWord")))
			{
				_Link_SEOKeyWord = (System.String)Rd["Link_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_SEODescription")))
			{
				_Link_SEODescription = (System.String)Rd["Link_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag1")))
			{
				_Link_ExFlag1 = (System.String)Rd["Link_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag2")))
			{
				_Link_ExFlag2 = (System.String)Rd["Link_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag3")))
			{
				_Link_ExFlag3 = (System.String)Rd["Link_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag4")))
			{
				_Link_ExFlag4 = (System.String)Rd["Link_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag5")))
			{
				_Link_ExFlag5 = (System.String)Rd["Link_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag6")))
			{
				_Link_ExFlag6 = (System.String)Rd["Link_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag7")))
			{
				_Link_ExFlag7 = (System.String)Rd["Link_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag8")))
			{
				_Link_ExFlag8 = (System.String)Rd["Link_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag9")))
			{
				_Link_ExFlag9 = (System.String)Rd["Link_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Link_ExFlag10")))
			{
				_Link_ExFlag10 = (System.String)Rd["Link_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Link();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Link([Link_CateId],[Link_CateName],[Link_Title],[Link_Url],[Link_Pic],[Link_Intro],[Link_AddTime],[Link_State],[Link_Order],[Link_SEOTitle],[Link_SEOKeyWord],[Link_SEODescription],[Link_ExFlag1],[Link_ExFlag2],[Link_ExFlag3],[Link_ExFlag4],[Link_ExFlag5],[Link_ExFlag6],[Link_ExFlag7],[Link_ExFlag8],[Link_ExFlag9],[Link_ExFlag10]) VALUES (@Link_CateId ,@Link_CateName ,@Link_Title ,@Link_Url ,@Link_Pic ,@Link_Intro ,@Link_AddTime ,@Link_State ,@Link_Order ,@Link_SEOTitle ,@Link_SEOKeyWord ,@Link_SEODescription ,@Link_ExFlag1 ,@Link_ExFlag2 ,@Link_ExFlag3 ,@Link_ExFlag4 ,@Link_ExFlag5 ,@Link_ExFlag6 ,@Link_ExFlag7 ,@Link_ExFlag8 ,@Link_ExFlag9 ,@Link_ExFlag10 )";
		}


	}

	public class Dcms_News:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "News_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_News";
		}

		private System.Int32 _News_Id;
		public System.Int32 News_Id
		{
			get{ return _News_Id; }
			set{ _News_Id = value; }
		}
		private System.Int32 _News_CateId;
		public System.Int32 News_CateId
		{
			get{ return _News_CateId; }
			set{ _News_CateId = value; }
		}
		private System.String _News_CateName;
		public System.String News_CateName
		{
			get{ return _News_CateName; }
			set{ _News_CateName = value; }
		}
		private System.String _News_Title;
		public System.String News_Title
		{
			get{ return _News_Title; }
			set{ _News_Title = value; }
		}
		private System.String _News_Image;
		public System.String News_Image
		{
			get{ return _News_Image; }
			set{ _News_Image = value; }
		}
		private System.String _News_Video;
		public System.String News_Video
		{
			get{ return _News_Video; }
			set{ _News_Video = value; }
		}
		private System.Int32 _News_Count;
		public System.Int32 News_Count
		{
			get{ return _News_Count; }
			set{ _News_Count = value; }
		}
		private System.String _News_Content;
		public System.String News_Content
		{
			get{ return _News_Content; }
			set{ _News_Content = value; }
		}
		private System.String _News_State;
		public System.String News_State
		{
			get{ return _News_State; }
			set{ _News_State = value; }
		}
		private System.String _News_Author;
		public System.String News_Author
		{
			get{ return _News_Author; }
			set{ _News_Author = value; }
		}
		private System.String _News_Source;
		public System.String News_Source
		{
			get{ return _News_Source; }
			set{ _News_Source = value; }
		}
		private System.String _News_IsIndex;
		public System.String News_IsIndex
		{
			get{ return _News_IsIndex; }
			set{ _News_IsIndex = value; }
		}
		private System.String _News_IsUrl;
		public System.String News_IsUrl
		{
			get{ return _News_IsUrl; }
			set{ _News_IsUrl = value; }
		}
		private System.String _News_Url;
		public System.String News_Url
		{
			get{ return _News_Url; }
			set{ _News_Url = value; }
		}
		private System.String _News_Target;
		public System.String News_Target
		{
			get{ return _News_Target; }
			set{ _News_Target = value; }
		}
		private System.DateTime _News_AddTime;
		public System.DateTime News_AddTime
		{
			get{ return _News_AddTime; }
			set{ _News_AddTime = value; }
		}
		private System.String _News_SEOTitle;
		public System.String News_SEOTitle
		{
			get{ return _News_SEOTitle; }
			set{ _News_SEOTitle = value; }
		}
		private System.String _News_SEOKeyWord;
		public System.String News_SEOKeyWord
		{
			get{ return _News_SEOKeyWord; }
			set{ _News_SEOKeyWord = value; }
		}
		private System.String _News_SEODescription;
		public System.String News_SEODescription
		{
			get{ return _News_SEODescription; }
			set{ _News_SEODescription = value; }
		}
		private System.String _News_ExFlag1;
		public System.String News_ExFlag1
		{
			get{ return _News_ExFlag1; }
			set{ _News_ExFlag1 = value; }
		}
		private System.String _News_ExFlag2;
		public System.String News_ExFlag2
		{
			get{ return _News_ExFlag2; }
			set{ _News_ExFlag2 = value; }
		}
		private System.String _News_ExFlag3;
		public System.String News_ExFlag3
		{
			get{ return _News_ExFlag3; }
			set{ _News_ExFlag3 = value; }
		}
		private System.String _News_ExFlag4;
		public System.String News_ExFlag4
		{
			get{ return _News_ExFlag4; }
			set{ _News_ExFlag4 = value; }
		}
		private System.String _News_ExFlag5;
		public System.String News_ExFlag5
		{
			get{ return _News_ExFlag5; }
			set{ _News_ExFlag5 = value; }
		}
		private System.String _News_ExFlag6;
		public System.String News_ExFlag6
		{
			get{ return _News_ExFlag6; }
			set{ _News_ExFlag6 = value; }
		}
		private System.String _News_ExFlag7;
		public System.String News_ExFlag7
		{
			get{ return _News_ExFlag7; }
			set{ _News_ExFlag7 = value; }
		}
		private System.String _News_ExFlag8;
		public System.String News_ExFlag8
		{
			get{ return _News_ExFlag8; }
			set{ _News_ExFlag8 = value; }
		}
		private System.String _News_ExFlag9;
		public System.String News_ExFlag9
		{
			get{ return _News_ExFlag9; }
			set{ _News_ExFlag9 = value; }
		}
		private System.String _News_ExFlag10;
		public System.String News_ExFlag10
		{
			get{ return _News_ExFlag10; }
			set{ _News_ExFlag10 = value; }
		}


		public static Exp _NEWS_ID_ = new Exp("News_Id");
		public static Exp _NEWS_CATEID_ = new Exp("News_CateId");
		public static Exp _NEWS_CATENAME_ = new Exp("News_CateName");
		public static Exp _NEWS_TITLE_ = new Exp("News_Title");
		public static Exp _NEWS_IMAGE_ = new Exp("News_Image");
		public static Exp _NEWS_VIDEO_ = new Exp("News_Video");
		public static Exp _NEWS_COUNT_ = new Exp("News_Count");
		public static Exp _NEWS_CONTENT_ = new Exp("News_Content");
		public static Exp _NEWS_STATE_ = new Exp("News_State");
		public static Exp _NEWS_AUTHOR_ = new Exp("News_Author");
		public static Exp _NEWS_SOURCE_ = new Exp("News_Source");
		public static Exp _NEWS_ISINDEX_ = new Exp("News_IsIndex");
		public static Exp _NEWS_ISURL_ = new Exp("News_IsUrl");
		public static Exp _NEWS_URL_ = new Exp("News_Url");
		public static Exp _NEWS_TARGET_ = new Exp("News_Target");
		public static Exp _NEWS_ADDTIME_ = new Exp("News_AddTime");
		public static Exp _NEWS_SEOTITLE_ = new Exp("News_SEOTitle");
		public static Exp _NEWS_SEOKEYWORD_ = new Exp("News_SEOKeyWord");
		public static Exp _NEWS_SEODESCRIPTION_ = new Exp("News_SEODescription");
		public static Exp _NEWS_EXFLAG1_ = new Exp("News_ExFlag1");
		public static Exp _NEWS_EXFLAG2_ = new Exp("News_ExFlag2");
		public static Exp _NEWS_EXFLAG3_ = new Exp("News_ExFlag3");
		public static Exp _NEWS_EXFLAG4_ = new Exp("News_ExFlag4");
		public static Exp _NEWS_EXFLAG5_ = new Exp("News_ExFlag5");
		public static Exp _NEWS_EXFLAG6_ = new Exp("News_ExFlag6");
		public static Exp _NEWS_EXFLAG7_ = new Exp("News_ExFlag7");
		public static Exp _NEWS_EXFLAG8_ = new Exp("News_ExFlag8");
		public static Exp _NEWS_EXFLAG9_ = new Exp("News_ExFlag9");
		public static Exp _NEWS_EXFLAG10_ = new Exp("News_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@News_Id",SqlDbType.Int);
			p.Value = _News_Id;
			rs.Add(p);
			p = new SqlParameter("@News_CateId",SqlDbType.Int);
			p.Value = _News_CateId;
			rs.Add(p);
			if (_News_CateName != null)
			{
				p = new SqlParameter("@News_CateName",SqlDbType.NVarChar);
				p.Value = _News_CateName;
				rs.Add(p);
			}
			if (_News_Title != null)
			{
				p = new SqlParameter("@News_Title",SqlDbType.NVarChar);
				p.Value = _News_Title;
				rs.Add(p);
			}
			if (_News_Image != null)
			{
				p = new SqlParameter("@News_Image",SqlDbType.NVarChar);
				p.Value = _News_Image;
				rs.Add(p);
			}
			if (_News_Video != null)
			{
				p = new SqlParameter("@News_Video",SqlDbType.NVarChar);
				p.Value = _News_Video;
				rs.Add(p);
			}
			p = new SqlParameter("@News_Count",SqlDbType.Int);
			p.Value = _News_Count;
			rs.Add(p);
			if (_News_Content != null)
			{
				p = new SqlParameter("@News_Content",SqlDbType.NText);
				p.Value = _News_Content;
				rs.Add(p);
			}
			if (_News_State != null)
			{
				p = new SqlParameter("@News_State",SqlDbType.NVarChar);
				p.Value = _News_State;
				rs.Add(p);
			}
			if (_News_Author != null)
			{
				p = new SqlParameter("@News_Author",SqlDbType.NVarChar);
				p.Value = _News_Author;
				rs.Add(p);
			}
			if (_News_Source != null)
			{
				p = new SqlParameter("@News_Source",SqlDbType.NVarChar);
				p.Value = _News_Source;
				rs.Add(p);
			}
			if (_News_IsIndex != null)
			{
				p = new SqlParameter("@News_IsIndex",SqlDbType.VarChar);
				p.Value = _News_IsIndex;
				rs.Add(p);
			}
			if (_News_IsUrl != null)
			{
				p = new SqlParameter("@News_IsUrl",SqlDbType.NVarChar);
				p.Value = _News_IsUrl;
				rs.Add(p);
			}
			if (_News_Url != null)
			{
				p = new SqlParameter("@News_Url",SqlDbType.NVarChar);
				p.Value = _News_Url;
				rs.Add(p);
			}
			if (_News_Target != null)
			{
				p = new SqlParameter("@News_Target",SqlDbType.NVarChar);
				p.Value = _News_Target;
				rs.Add(p);
			}
			if (_News_AddTime != null)
			{
				if (_News_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@News_AddTime",SqlDbType.SmallDateTime);
					p.Value = _News_AddTime;
					rs.Add(p);
				}
			}
			if (_News_SEOTitle != null)
			{
				p = new SqlParameter("@News_SEOTitle",SqlDbType.NVarChar);
				p.Value = _News_SEOTitle;
				rs.Add(p);
			}
			if (_News_SEOKeyWord != null)
			{
				p = new SqlParameter("@News_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _News_SEOKeyWord;
				rs.Add(p);
			}
			if (_News_SEODescription != null)
			{
				p = new SqlParameter("@News_SEODescription",SqlDbType.NVarChar);
				p.Value = _News_SEODescription;
				rs.Add(p);
			}
			if (_News_ExFlag1 != null)
			{
				p = new SqlParameter("@News_ExFlag1",SqlDbType.NText);
				p.Value = _News_ExFlag1;
				rs.Add(p);
			}
			if (_News_ExFlag2 != null)
			{
				p = new SqlParameter("@News_ExFlag2",SqlDbType.NText);
				p.Value = _News_ExFlag2;
				rs.Add(p);
			}
			if (_News_ExFlag3 != null)
			{
				p = new SqlParameter("@News_ExFlag3",SqlDbType.NText);
				p.Value = _News_ExFlag3;
				rs.Add(p);
			}
			if (_News_ExFlag4 != null)
			{
				p = new SqlParameter("@News_ExFlag4",SqlDbType.NText);
				p.Value = _News_ExFlag4;
				rs.Add(p);
			}
			if (_News_ExFlag5 != null)
			{
				p = new SqlParameter("@News_ExFlag5",SqlDbType.NText);
				p.Value = _News_ExFlag5;
				rs.Add(p);
			}
			if (_News_ExFlag6 != null)
			{
				p = new SqlParameter("@News_ExFlag6",SqlDbType.NText);
				p.Value = _News_ExFlag6;
				rs.Add(p);
			}
			if (_News_ExFlag7 != null)
			{
				p = new SqlParameter("@News_ExFlag7",SqlDbType.NText);
				p.Value = _News_ExFlag7;
				rs.Add(p);
			}
			if (_News_ExFlag8 != null)
			{
				p = new SqlParameter("@News_ExFlag8",SqlDbType.NText);
				p.Value = _News_ExFlag8;
				rs.Add(p);
			}
			if (_News_ExFlag9 != null)
			{
				p = new SqlParameter("@News_ExFlag9",SqlDbType.NText);
				p.Value = _News_ExFlag9;
				rs.Add(p);
			}
			if (_News_ExFlag10 != null)
			{
				p = new SqlParameter("@News_ExFlag10",SqlDbType.NText);
				p.Value = _News_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Id")))
			{
				_News_Id = (System.Int32)Rd["News_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_CateId")))
			{
				_News_CateId = (System.Int32)Rd["News_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_CateName")))
			{
				_News_CateName = (System.String)Rd["News_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Title")))
			{
				_News_Title = (System.String)Rd["News_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Image")))
			{
				_News_Image = (System.String)Rd["News_Image"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Video")))
			{
				_News_Video = (System.String)Rd["News_Video"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Count")))
			{
				_News_Count = (System.Int32)Rd["News_Count"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Content")))
			{
				_News_Content = (System.String)Rd["News_Content"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_State")))
			{
				_News_State = (System.String)Rd["News_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Author")))
			{
				_News_Author = (System.String)Rd["News_Author"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Source")))
			{
				_News_Source = (System.String)Rd["News_Source"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_IsIndex")))
			{
				_News_IsIndex = (System.String)Rd["News_IsIndex"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_IsUrl")))
			{
				_News_IsUrl = (System.String)Rd["News_IsUrl"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Url")))
			{
				_News_Url = (System.String)Rd["News_Url"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_Target")))
			{
				_News_Target = (System.String)Rd["News_Target"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_AddTime")))
			{
				_News_AddTime = (System.DateTime)Rd["News_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_SEOTitle")))
			{
				_News_SEOTitle = (System.String)Rd["News_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_SEOKeyWord")))
			{
				_News_SEOKeyWord = (System.String)Rd["News_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_SEODescription")))
			{
				_News_SEODescription = (System.String)Rd["News_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag1")))
			{
				_News_ExFlag1 = (System.String)Rd["News_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag2")))
			{
				_News_ExFlag2 = (System.String)Rd["News_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag3")))
			{
				_News_ExFlag3 = (System.String)Rd["News_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag4")))
			{
				_News_ExFlag4 = (System.String)Rd["News_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag5")))
			{
				_News_ExFlag5 = (System.String)Rd["News_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag6")))
			{
				_News_ExFlag6 = (System.String)Rd["News_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag7")))
			{
				_News_ExFlag7 = (System.String)Rd["News_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag8")))
			{
				_News_ExFlag8 = (System.String)Rd["News_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag9")))
			{
				_News_ExFlag9 = (System.String)Rd["News_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("News_ExFlag10")))
			{
				_News_ExFlag10 = (System.String)Rd["News_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_News();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_News([News_CateId],[News_CateName],[News_Title],[News_Image],[News_Video],[News_Count],[News_Content],[News_State],[News_Author],[News_Source],[News_IsIndex],[News_IsUrl],[News_Url],[News_Target],[News_AddTime],[News_SEOTitle],[News_SEOKeyWord],[News_SEODescription],[News_ExFlag1],[News_ExFlag2],[News_ExFlag3],[News_ExFlag4],[News_ExFlag5],[News_ExFlag6],[News_ExFlag7],[News_ExFlag8],[News_ExFlag9],[News_ExFlag10]) VALUES (@News_CateId ,@News_CateName ,@News_Title ,@News_Image ,@News_Video ,@News_Count ,@News_Content ,@News_State ,@News_Author ,@News_Source ,@News_IsIndex ,@News_IsUrl ,@News_Url ,@News_Target ,@News_AddTime ,@News_SEOTitle ,@News_SEOKeyWord ,@News_SEODescription ,@News_ExFlag1 ,@News_ExFlag2 ,@News_ExFlag3 ,@News_ExFlag4 ,@News_ExFlag5 ,@News_ExFlag6 ,@News_ExFlag7 ,@News_ExFlag8 ,@News_ExFlag9 ,@News_ExFlag10 )";
		}


	}

	public class Dcms_Permissions:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Permissions_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Permissions";
		}

		private System.Int32 _Permissions_Id;
		public System.Int32 Permissions_Id
		{
			get{ return _Permissions_Id; }
			set{ _Permissions_Id = value; }
		}
		private System.Int32 _Permissions_CateId;
		public System.Int32 Permissions_CateId
		{
			get{ return _Permissions_CateId; }
			set{ _Permissions_CateId = value; }
		}
		private System.Int32 _Permissions_RoleId;
		public System.Int32 Permissions_RoleId
		{
			get{ return _Permissions_RoleId; }
			set{ _Permissions_RoleId = value; }
		}
		private System.Int32 _Permissions_AdminId;
		public System.Int32 Permissions_AdminId
		{
			get{ return _Permissions_AdminId; }
			set{ _Permissions_AdminId = value; }
		}
		private System.Int32 _Permissions_Select;
		public System.Int32 Permissions_Select
		{
			get{ return _Permissions_Select; }
			set{ _Permissions_Select = value; }
		}
		private System.Int32 _Permissions_Insert;
		public System.Int32 Permissions_Insert
		{
			get{ return _Permissions_Insert; }
			set{ _Permissions_Insert = value; }
		}
		private System.Int32 _Permissions_Update;
		public System.Int32 Permissions_Update
		{
			get{ return _Permissions_Update; }
			set{ _Permissions_Update = value; }
		}
		private System.Int32 _Permissions_Delete;
		public System.Int32 Permissions_Delete
		{
			get{ return _Permissions_Delete; }
			set{ _Permissions_Delete = value; }
		}


		public static Exp _PERMISSIONS_ID_ = new Exp("Permissions_Id");
		public static Exp _PERMISSIONS_CATEID_ = new Exp("Permissions_CateId");
		public static Exp _PERMISSIONS_ROLEID_ = new Exp("Permissions_RoleId");
		public static Exp _PERMISSIONS_ADMINID_ = new Exp("Permissions_AdminId");
		public static Exp _PERMISSIONS_SELECT_ = new Exp("Permissions_Select");
		public static Exp _PERMISSIONS_INSERT_ = new Exp("Permissions_Insert");
		public static Exp _PERMISSIONS_UPDATE_ = new Exp("Permissions_Update");
		public static Exp _PERMISSIONS_DELETE_ = new Exp("Permissions_Delete");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Permissions_Id",SqlDbType.Int);
			p.Value = _Permissions_Id;
			rs.Add(p);
			p = new SqlParameter("@Permissions_CateId",SqlDbType.Int);
			p.Value = _Permissions_CateId;
			rs.Add(p);
			p = new SqlParameter("@Permissions_RoleId",SqlDbType.Int);
			p.Value = _Permissions_RoleId;
			rs.Add(p);
			p = new SqlParameter("@Permissions_AdminId",SqlDbType.Int);
			p.Value = _Permissions_AdminId;
			rs.Add(p);
			p = new SqlParameter("@Permissions_Select",SqlDbType.Int);
			p.Value = _Permissions_Select;
			rs.Add(p);
			p = new SqlParameter("@Permissions_Insert",SqlDbType.Int);
			p.Value = _Permissions_Insert;
			rs.Add(p);
			p = new SqlParameter("@Permissions_Update",SqlDbType.Int);
			p.Value = _Permissions_Update;
			rs.Add(p);
			p = new SqlParameter("@Permissions_Delete",SqlDbType.Int);
			p.Value = _Permissions_Delete;
			rs.Add(p);
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_Id")))
			{
				_Permissions_Id = (System.Int32)Rd["Permissions_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_CateId")))
			{
				_Permissions_CateId = (System.Int32)Rd["Permissions_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_RoleId")))
			{
				_Permissions_RoleId = (System.Int32)Rd["Permissions_RoleId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_AdminId")))
			{
				_Permissions_AdminId = (System.Int32)Rd["Permissions_AdminId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_Select")))
			{
				_Permissions_Select = (System.Int32)Rd["Permissions_Select"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_Insert")))
			{
				_Permissions_Insert = (System.Int32)Rd["Permissions_Insert"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_Update")))
			{
				_Permissions_Update = (System.Int32)Rd["Permissions_Update"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Permissions_Delete")))
			{
				_Permissions_Delete = (System.Int32)Rd["Permissions_Delete"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Permissions();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Permissions([Permissions_CateId],[Permissions_RoleId],[Permissions_AdminId],[Permissions_Select],[Permissions_Insert],[Permissions_Update],[Permissions_Delete]) VALUES (@Permissions_CateId ,@Permissions_RoleId ,@Permissions_AdminId ,@Permissions_Select ,@Permissions_Insert ,@Permissions_Update ,@Permissions_Delete )";
		}


	}

	public class Dcms_Position:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Position_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Position";
		}

		private System.Int32 _Position_Id;
		public System.Int32 Position_Id
		{
			get{ return _Position_Id; }
			set{ _Position_Id = value; }
		}
		private System.Int32 _Position_CateId;
		public System.Int32 Position_CateId
		{
			get{ return _Position_CateId; }
			set{ _Position_CateId = value; }
		}
		private System.String _Position_CateName;
		public System.String Position_CateName
		{
			get{ return _Position_CateName; }
			set{ _Position_CateName = value; }
		}
		private System.String _Position_Title;
		public System.String Position_Title
		{
			get{ return _Position_Title; }
			set{ _Position_Title = value; }
		}
		private System.String _Position_Num;
		public System.String Position_Num
		{
			get{ return _Position_Num; }
			set{ _Position_Num = value; }
		}
		private System.String _Position_Area;
		public System.String Position_Area
		{
			get{ return _Position_Area; }
			set{ _Position_Area = value; }
		}
		private System.DateTime _Position_AddTime;
		public System.DateTime Position_AddTime
		{
			get{ return _Position_AddTime; }
			set{ _Position_AddTime = value; }
		}
		private System.DateTime _Position_ValidTime;
		public System.DateTime Position_ValidTime
		{
			get{ return _Position_ValidTime; }
			set{ _Position_ValidTime = value; }
		}
		private System.String _Position_Description;
		public System.String Position_Description
		{
			get{ return _Position_Description; }
			set{ _Position_Description = value; }
		}
		private System.String _Position_Conditions;
		public System.String Position_Conditions
		{
			get{ return _Position_Conditions; }
			set{ _Position_Conditions = value; }
		}
		private System.String _Position_Contact;
		public System.String Position_Contact
		{
			get{ return _Position_Contact; }
			set{ _Position_Contact = value; }
		}
		private System.Int32 _Position_Count;
		public System.Int32 Position_Count
		{
			get{ return _Position_Count; }
			set{ _Position_Count = value; }
		}
		private System.String _Position_Departments;
		public System.String Position_Departments
		{
			get{ return _Position_Departments; }
			set{ _Position_Departments = value; }
		}
		private System.String _Position_State;
		public System.String Position_State
		{
			get{ return _Position_State; }
			set{ _Position_State = value; }
		}
		private System.String _Position_Edu;
		public System.String Position_Edu
		{
			get{ return _Position_Edu; }
			set{ _Position_Edu = value; }
		}
		private System.String _Position_ExFlag1;
		public System.String Position_ExFlag1
		{
			get{ return _Position_ExFlag1; }
			set{ _Position_ExFlag1 = value; }
		}
		private System.String _Position_ExFlag2;
		public System.String Position_ExFlag2
		{
			get{ return _Position_ExFlag2; }
			set{ _Position_ExFlag2 = value; }
		}
		private System.String _Position_ExFlag3;
		public System.String Position_ExFlag3
		{
			get{ return _Position_ExFlag3; }
			set{ _Position_ExFlag3 = value; }
		}
		private System.String _Position_ExFlag4;
		public System.String Position_ExFlag4
		{
			get{ return _Position_ExFlag4; }
			set{ _Position_ExFlag4 = value; }
		}
		private System.String _Position_ExFlag5;
		public System.String Position_ExFlag5
		{
			get{ return _Position_ExFlag5; }
			set{ _Position_ExFlag5 = value; }
		}
		private System.String _Position_ExFlag6;
		public System.String Position_ExFlag6
		{
			get{ return _Position_ExFlag6; }
			set{ _Position_ExFlag6 = value; }
		}
		private System.String _Position_ExFlag7;
		public System.String Position_ExFlag7
		{
			get{ return _Position_ExFlag7; }
			set{ _Position_ExFlag7 = value; }
		}
		private System.String _Position_ExFlag8;
		public System.String Position_ExFlag8
		{
			get{ return _Position_ExFlag8; }
			set{ _Position_ExFlag8 = value; }
		}
		private System.String _Position_ExFlag9;
		public System.String Position_ExFlag9
		{
			get{ return _Position_ExFlag9; }
			set{ _Position_ExFlag9 = value; }
		}
		private System.String _Position_ExFlag10;
		public System.String Position_ExFlag10
		{
			get{ return _Position_ExFlag10; }
			set{ _Position_ExFlag10 = value; }
		}


		public static Exp _POSITION_ID_ = new Exp("Position_Id");
		public static Exp _POSITION_CATEID_ = new Exp("Position_CateId");
		public static Exp _POSITION_CATENAME_ = new Exp("Position_CateName");
		public static Exp _POSITION_TITLE_ = new Exp("Position_Title");
		public static Exp _POSITION_NUM_ = new Exp("Position_Num");
		public static Exp _POSITION_AREA_ = new Exp("Position_Area");
		public static Exp _POSITION_ADDTIME_ = new Exp("Position_AddTime");
		public static Exp _POSITION_VALIDTIME_ = new Exp("Position_ValidTime");
		public static Exp _POSITION_DESCRIPTION_ = new Exp("Position_Description");
		public static Exp _POSITION_CONDITIONS_ = new Exp("Position_Conditions");
		public static Exp _POSITION_CONTACT_ = new Exp("Position_Contact");
		public static Exp _POSITION_COUNT_ = new Exp("Position_Count");
		public static Exp _POSITION_DEPARTMENTS_ = new Exp("Position_Departments");
		public static Exp _POSITION_STATE_ = new Exp("Position_State");
		public static Exp _POSITION_EDU_ = new Exp("Position_Edu");
		public static Exp _POSITION_EXFLAG1_ = new Exp("Position_ExFlag1");
		public static Exp _POSITION_EXFLAG2_ = new Exp("Position_ExFlag2");
		public static Exp _POSITION_EXFLAG3_ = new Exp("Position_ExFlag3");
		public static Exp _POSITION_EXFLAG4_ = new Exp("Position_ExFlag4");
		public static Exp _POSITION_EXFLAG5_ = new Exp("Position_ExFlag5");
		public static Exp _POSITION_EXFLAG6_ = new Exp("Position_ExFlag6");
		public static Exp _POSITION_EXFLAG7_ = new Exp("Position_ExFlag7");
		public static Exp _POSITION_EXFLAG8_ = new Exp("Position_ExFlag8");
		public static Exp _POSITION_EXFLAG9_ = new Exp("Position_ExFlag9");
		public static Exp _POSITION_EXFLAG10_ = new Exp("Position_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Position_Id",SqlDbType.Int);
			p.Value = _Position_Id;
			rs.Add(p);
			p = new SqlParameter("@Position_CateId",SqlDbType.Int);
			p.Value = _Position_CateId;
			rs.Add(p);
			if (_Position_CateName != null)
			{
				p = new SqlParameter("@Position_CateName",SqlDbType.NVarChar);
				p.Value = _Position_CateName;
				rs.Add(p);
			}
			if (_Position_Title != null)
			{
				p = new SqlParameter("@Position_Title",SqlDbType.VarChar);
				p.Value = _Position_Title;
				rs.Add(p);
			}
			if (_Position_Num != null)
			{
				p = new SqlParameter("@Position_Num",SqlDbType.VarChar);
				p.Value = _Position_Num;
				rs.Add(p);
			}
			if (_Position_Area != null)
			{
				p = new SqlParameter("@Position_Area",SqlDbType.VarChar);
				p.Value = _Position_Area;
				rs.Add(p);
			}
			if (_Position_AddTime != null)
			{
				if (_Position_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Position_AddTime",SqlDbType.DateTime);
					p.Value = _Position_AddTime;
					rs.Add(p);
				}
			}
			if (_Position_ValidTime != null)
			{
				if (_Position_ValidTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Position_ValidTime",SqlDbType.DateTime);
					p.Value = _Position_ValidTime;
					rs.Add(p);
				}
			}
			if (_Position_Description != null)
			{
				p = new SqlParameter("@Position_Description",SqlDbType.Text);
				p.Value = _Position_Description;
				rs.Add(p);
			}
			if (_Position_Conditions != null)
			{
				p = new SqlParameter("@Position_Conditions",SqlDbType.Text);
				p.Value = _Position_Conditions;
				rs.Add(p);
			}
			if (_Position_Contact != null)
			{
				p = new SqlParameter("@Position_Contact",SqlDbType.Text);
				p.Value = _Position_Contact;
				rs.Add(p);
			}
			p = new SqlParameter("@Position_Count",SqlDbType.Int);
			p.Value = _Position_Count;
			rs.Add(p);
			if (_Position_Departments != null)
			{
				p = new SqlParameter("@Position_Departments",SqlDbType.VarChar);
				p.Value = _Position_Departments;
				rs.Add(p);
			}
			if (_Position_State != null)
			{
				p = new SqlParameter("@Position_State",SqlDbType.VarChar);
				p.Value = _Position_State;
				rs.Add(p);
			}
			if (_Position_Edu != null)
			{
				p = new SqlParameter("@Position_Edu",SqlDbType.VarChar);
				p.Value = _Position_Edu;
				rs.Add(p);
			}
			if (_Position_ExFlag1 != null)
			{
				p = new SqlParameter("@Position_ExFlag1",SqlDbType.Text);
				p.Value = _Position_ExFlag1;
				rs.Add(p);
			}
			if (_Position_ExFlag2 != null)
			{
				p = new SqlParameter("@Position_ExFlag2",SqlDbType.Text);
				p.Value = _Position_ExFlag2;
				rs.Add(p);
			}
			if (_Position_ExFlag3 != null)
			{
				p = new SqlParameter("@Position_ExFlag3",SqlDbType.Text);
				p.Value = _Position_ExFlag3;
				rs.Add(p);
			}
			if (_Position_ExFlag4 != null)
			{
				p = new SqlParameter("@Position_ExFlag4",SqlDbType.Text);
				p.Value = _Position_ExFlag4;
				rs.Add(p);
			}
			if (_Position_ExFlag5 != null)
			{
				p = new SqlParameter("@Position_ExFlag5",SqlDbType.Text);
				p.Value = _Position_ExFlag5;
				rs.Add(p);
			}
			if (_Position_ExFlag6 != null)
			{
				p = new SqlParameter("@Position_ExFlag6",SqlDbType.Text);
				p.Value = _Position_ExFlag6;
				rs.Add(p);
			}
			if (_Position_ExFlag7 != null)
			{
				p = new SqlParameter("@Position_ExFlag7",SqlDbType.Text);
				p.Value = _Position_ExFlag7;
				rs.Add(p);
			}
			if (_Position_ExFlag8 != null)
			{
				p = new SqlParameter("@Position_ExFlag8",SqlDbType.Text);
				p.Value = _Position_ExFlag8;
				rs.Add(p);
			}
			if (_Position_ExFlag9 != null)
			{
				p = new SqlParameter("@Position_ExFlag9",SqlDbType.Text);
				p.Value = _Position_ExFlag9;
				rs.Add(p);
			}
			if (_Position_ExFlag10 != null)
			{
				p = new SqlParameter("@Position_ExFlag10",SqlDbType.Text);
				p.Value = _Position_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Id")))
			{
				_Position_Id = (System.Int32)Rd["Position_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_CateId")))
			{
				_Position_CateId = (System.Int32)Rd["Position_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_CateName")))
			{
				_Position_CateName = (System.String)Rd["Position_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Title")))
			{
				_Position_Title = (System.String)Rd["Position_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Num")))
			{
				_Position_Num = (System.String)Rd["Position_Num"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Area")))
			{
				_Position_Area = (System.String)Rd["Position_Area"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_AddTime")))
			{
				_Position_AddTime = (System.DateTime)Rd["Position_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ValidTime")))
			{
				_Position_ValidTime = (System.DateTime)Rd["Position_ValidTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Description")))
			{
				_Position_Description = (System.String)Rd["Position_Description"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Conditions")))
			{
				_Position_Conditions = (System.String)Rd["Position_Conditions"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Contact")))
			{
				_Position_Contact = (System.String)Rd["Position_Contact"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Count")))
			{
				_Position_Count = (System.Int32)Rd["Position_Count"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Departments")))
			{
				_Position_Departments = (System.String)Rd["Position_Departments"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_State")))
			{
				_Position_State = (System.String)Rd["Position_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_Edu")))
			{
				_Position_Edu = (System.String)Rd["Position_Edu"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag1")))
			{
				_Position_ExFlag1 = (System.String)Rd["Position_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag2")))
			{
				_Position_ExFlag2 = (System.String)Rd["Position_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag3")))
			{
				_Position_ExFlag3 = (System.String)Rd["Position_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag4")))
			{
				_Position_ExFlag4 = (System.String)Rd["Position_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag5")))
			{
				_Position_ExFlag5 = (System.String)Rd["Position_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag6")))
			{
				_Position_ExFlag6 = (System.String)Rd["Position_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag7")))
			{
				_Position_ExFlag7 = (System.String)Rd["Position_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag8")))
			{
				_Position_ExFlag8 = (System.String)Rd["Position_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag9")))
			{
				_Position_ExFlag9 = (System.String)Rd["Position_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Position_ExFlag10")))
			{
				_Position_ExFlag10 = (System.String)Rd["Position_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Position();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Position([Position_CateId],[Position_CateName],[Position_Title],[Position_Num],[Position_Area],[Position_AddTime],[Position_ValidTime],[Position_Description],[Position_Conditions],[Position_Contact],[Position_Count],[Position_Departments],[Position_State],[Position_Edu],[Position_ExFlag1],[Position_ExFlag2],[Position_ExFlag3],[Position_ExFlag4],[Position_ExFlag5],[Position_ExFlag6],[Position_ExFlag7],[Position_ExFlag8],[Position_ExFlag9],[Position_ExFlag10]) VALUES (@Position_CateId ,@Position_CateName ,@Position_Title ,@Position_Num ,@Position_Area ,@Position_AddTime ,@Position_ValidTime ,@Position_Description ,@Position_Conditions ,@Position_Contact ,@Position_Count ,@Position_Departments ,@Position_State ,@Position_Edu ,@Position_ExFlag1 ,@Position_ExFlag2 ,@Position_ExFlag3 ,@Position_ExFlag4 ,@Position_ExFlag5 ,@Position_ExFlag6 ,@Position_ExFlag7 ,@Position_ExFlag8 ,@Position_ExFlag9 ,@Position_ExFlag10 )";
		}


	}

	public class Dcms_Products:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Products_ID";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Products";
		}

		private System.Int32 _Products_ID;
		public System.Int32 Products_ID
		{
			get{ return _Products_ID; }
			set{ _Products_ID = value; }
		}
		private System.Int32 _Products_CateID;
		public System.Int32 Products_CateID
		{
			get{ return _Products_CateID; }
			set{ _Products_CateID = value; }
		}
		private System.String _Products_CateName;
		public System.String Products_CateName
		{
			get{ return _Products_CateName; }
			set{ _Products_CateName = value; }
		}
		private System.String _Products_Title;
		public System.String Products_Title
		{
			get{ return _Products_Title; }
			set{ _Products_Title = value; }
		}
		private System.String _Products_CodeName;
		public System.String Products_CodeName
		{
			get{ return _Products_CodeName; }
			set{ _Products_CodeName = value; }
		}
		private System.Int32 _Products_Count;
		public System.Int32 Products_Count
		{
			get{ return _Products_Count; }
			set{ _Products_Count = value; }
		}
		private System.Int32 _Products_Order;
		public System.Int32 Products_Order
		{
			get{ return _Products_Order; }
			set{ _Products_Order = value; }
		}
		private System.String _Products_State;
		public System.String Products_State
		{
			get{ return _Products_State; }
			set{ _Products_State = value; }
		}
		private System.DateTime _Products_AddTime;
		public System.DateTime Products_AddTime
		{
			get{ return _Products_AddTime; }
			set{ _Products_AddTime = value; }
		}
		private System.String _Products_IsHot;
		public System.String Products_IsHot
		{
			get{ return _Products_IsHot; }
			set{ _Products_IsHot = value; }
		}
		private System.String _Products_IsNew;
		public System.String Products_IsNew
		{
			get{ return _Products_IsNew; }
			set{ _Products_IsNew = value; }
		}
		private System.String _Products_Prices;
		public System.String Products_Prices
		{
			get{ return _Products_Prices; }
			set{ _Products_Prices = value; }
		}
		private System.String _Products_BigImage;
		public System.String Products_BigImage
		{
			get{ return _Products_BigImage; }
			set{ _Products_BigImage = value; }
		}
		private System.String _Products_MinImage;
		public System.String Products_MinImage
		{
			get{ return _Products_MinImage; }
			set{ _Products_MinImage = value; }
		}
		private System.String _Products_FileIntro;
		public System.String Products_FileIntro
		{
			get{ return _Products_FileIntro; }
			set{ _Products_FileIntro = value; }
		}
		private System.String _Products_Introduction;
		public System.String Products_Introduction
		{
			get{ return _Products_Introduction; }
			set{ _Products_Introduction = value; }
		}
		private System.String _Products_OtherInfo;
		public System.String Products_OtherInfo
		{
			get{ return _Products_OtherInfo; }
			set{ _Products_OtherInfo = value; }
		}
		private System.String _Products_SEOTitle;
		public System.String Products_SEOTitle
		{
			get{ return _Products_SEOTitle; }
			set{ _Products_SEOTitle = value; }
		}
		private System.String _Products_SEOKeyWord;
		public System.String Products_SEOKeyWord
		{
			get{ return _Products_SEOKeyWord; }
			set{ _Products_SEOKeyWord = value; }
		}
		private System.String _Products_SEODescription;
		public System.String Products_SEODescription
		{
			get{ return _Products_SEODescription; }
			set{ _Products_SEODescription = value; }
		}
		private System.String _Products_ExFlag1;
		public System.String Products_ExFlag1
		{
			get{ return _Products_ExFlag1; }
			set{ _Products_ExFlag1 = value; }
		}
		private System.String _Products_ExFlag2;
		public System.String Products_ExFlag2
		{
			get{ return _Products_ExFlag2; }
			set{ _Products_ExFlag2 = value; }
		}
		private System.String _Products_ExFlag3;
		public System.String Products_ExFlag3
		{
			get{ return _Products_ExFlag3; }
			set{ _Products_ExFlag3 = value; }
		}
		private System.String _Products_ExFlag4;
		public System.String Products_ExFlag4
		{
			get{ return _Products_ExFlag4; }
			set{ _Products_ExFlag4 = value; }
		}
		private System.String _Products_ExFlag5;
		public System.String Products_ExFlag5
		{
			get{ return _Products_ExFlag5; }
			set{ _Products_ExFlag5 = value; }
		}
		private System.String _Products_ExFlag6;
		public System.String Products_ExFlag6
		{
			get{ return _Products_ExFlag6; }
			set{ _Products_ExFlag6 = value; }
		}
		private System.String _Products_ExFlag7;
		public System.String Products_ExFlag7
		{
			get{ return _Products_ExFlag7; }
			set{ _Products_ExFlag7 = value; }
		}
		private System.String _Products_ExFlag8;
		public System.String Products_ExFlag8
		{
			get{ return _Products_ExFlag8; }
			set{ _Products_ExFlag8 = value; }
		}
		private System.String _Products_ExFlag9;
		public System.String Products_ExFlag9
		{
			get{ return _Products_ExFlag9; }
			set{ _Products_ExFlag9 = value; }
		}
		private System.String _Products_ExFlag10;
		public System.String Products_ExFlag10
		{
			get{ return _Products_ExFlag10; }
			set{ _Products_ExFlag10 = value; }
		}


		public static Exp _PRODUCTS_ID_ = new Exp("Products_ID");
		public static Exp _PRODUCTS_CATEID_ = new Exp("Products_CateID");
		public static Exp _PRODUCTS_CATENAME_ = new Exp("Products_CateName");
		public static Exp _PRODUCTS_TITLE_ = new Exp("Products_Title");
		public static Exp _PRODUCTS_CODENAME_ = new Exp("Products_CodeName");
		public static Exp _PRODUCTS_COUNT_ = new Exp("Products_Count");
		public static Exp _PRODUCTS_ORDER_ = new Exp("Products_Order");
		public static Exp _PRODUCTS_STATE_ = new Exp("Products_State");
		public static Exp _PRODUCTS_ADDTIME_ = new Exp("Products_AddTime");
		public static Exp _PRODUCTS_ISHOT_ = new Exp("Products_IsHot");
		public static Exp _PRODUCTS_ISNEW_ = new Exp("Products_IsNew");
		public static Exp _PRODUCTS_PRICES_ = new Exp("Products_Prices");
		public static Exp _PRODUCTS_BIGIMAGE_ = new Exp("Products_BigImage");
		public static Exp _PRODUCTS_MINIMAGE_ = new Exp("Products_MinImage");
		public static Exp _PRODUCTS_FILEINTRO_ = new Exp("Products_FileIntro");
		public static Exp _PRODUCTS_INTRODUCTION_ = new Exp("Products_Introduction");
		public static Exp _PRODUCTS_OTHERINFO_ = new Exp("Products_OtherInfo");
		public static Exp _PRODUCTS_SEOTITLE_ = new Exp("Products_SEOTitle");
		public static Exp _PRODUCTS_SEOKEYWORD_ = new Exp("Products_SEOKeyWord");
		public static Exp _PRODUCTS_SEODESCRIPTION_ = new Exp("Products_SEODescription");
		public static Exp _PRODUCTS_EXFLAG1_ = new Exp("Products_ExFlag1");
		public static Exp _PRODUCTS_EXFLAG2_ = new Exp("Products_ExFlag2");
		public static Exp _PRODUCTS_EXFLAG3_ = new Exp("Products_ExFlag3");
		public static Exp _PRODUCTS_EXFLAG4_ = new Exp("Products_ExFlag4");
		public static Exp _PRODUCTS_EXFLAG5_ = new Exp("Products_ExFlag5");
		public static Exp _PRODUCTS_EXFLAG6_ = new Exp("Products_ExFlag6");
		public static Exp _PRODUCTS_EXFLAG7_ = new Exp("Products_ExFlag7");
		public static Exp _PRODUCTS_EXFLAG8_ = new Exp("Products_ExFlag8");
		public static Exp _PRODUCTS_EXFLAG9_ = new Exp("Products_ExFlag9");
		public static Exp _PRODUCTS_EXFLAG10_ = new Exp("Products_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Products_ID",SqlDbType.Int);
			p.Value = _Products_ID;
			rs.Add(p);
			p = new SqlParameter("@Products_CateID",SqlDbType.Int);
			p.Value = _Products_CateID;
			rs.Add(p);
			if (_Products_CateName != null)
			{
				p = new SqlParameter("@Products_CateName",SqlDbType.NVarChar);
				p.Value = _Products_CateName;
				rs.Add(p);
			}
			if (_Products_Title != null)
			{
				p = new SqlParameter("@Products_Title",SqlDbType.NVarChar);
				p.Value = _Products_Title;
				rs.Add(p);
			}
			if (_Products_CodeName != null)
			{
				p = new SqlParameter("@Products_CodeName",SqlDbType.NVarChar);
				p.Value = _Products_CodeName;
				rs.Add(p);
			}
			p = new SqlParameter("@Products_Count",SqlDbType.Int);
			p.Value = _Products_Count;
			rs.Add(p);
			p = new SqlParameter("@Products_Order",SqlDbType.Int);
			p.Value = _Products_Order;
			rs.Add(p);
			if (_Products_State != null)
			{
				p = new SqlParameter("@Products_State",SqlDbType.NVarChar);
				p.Value = _Products_State;
				rs.Add(p);
			}
			if (_Products_AddTime != null)
			{
				if (_Products_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Products_AddTime",SqlDbType.DateTime);
					p.Value = _Products_AddTime;
					rs.Add(p);
				}
			}
			if (_Products_IsHot != null)
			{
				p = new SqlParameter("@Products_IsHot",SqlDbType.NVarChar);
				p.Value = _Products_IsHot;
				rs.Add(p);
			}
			if (_Products_IsNew != null)
			{
				p = new SqlParameter("@Products_IsNew",SqlDbType.NVarChar);
				p.Value = _Products_IsNew;
				rs.Add(p);
			}
			if (_Products_Prices != null)
			{
				p = new SqlParameter("@Products_Prices",SqlDbType.NVarChar);
				p.Value = _Products_Prices;
				rs.Add(p);
			}
			if (_Products_BigImage != null)
			{
				p = new SqlParameter("@Products_BigImage",SqlDbType.NVarChar);
				p.Value = _Products_BigImage;
				rs.Add(p);
			}
			if (_Products_MinImage != null)
			{
				p = new SqlParameter("@Products_MinImage",SqlDbType.NVarChar);
				p.Value = _Products_MinImage;
				rs.Add(p);
			}
			if (_Products_FileIntro != null)
			{
				p = new SqlParameter("@Products_FileIntro",SqlDbType.NVarChar);
				p.Value = _Products_FileIntro;
				rs.Add(p);
			}
			if (_Products_Introduction != null)
			{
				p = new SqlParameter("@Products_Introduction",SqlDbType.NText);
				p.Value = _Products_Introduction;
				rs.Add(p);
			}
			if (_Products_OtherInfo != null)
			{
				p = new SqlParameter("@Products_OtherInfo",SqlDbType.NText);
				p.Value = _Products_OtherInfo;
				rs.Add(p);
			}
			if (_Products_SEOTitle != null)
			{
				p = new SqlParameter("@Products_SEOTitle",SqlDbType.NVarChar);
				p.Value = _Products_SEOTitle;
				rs.Add(p);
			}
			if (_Products_SEOKeyWord != null)
			{
				p = new SqlParameter("@Products_SEOKeyWord",SqlDbType.NVarChar);
				p.Value = _Products_SEOKeyWord;
				rs.Add(p);
			}
			if (_Products_SEODescription != null)
			{
				p = new SqlParameter("@Products_SEODescription",SqlDbType.NVarChar);
				p.Value = _Products_SEODescription;
				rs.Add(p);
			}
			if (_Products_ExFlag1 != null)
			{
				p = new SqlParameter("@Products_ExFlag1",SqlDbType.NText);
				p.Value = _Products_ExFlag1;
				rs.Add(p);
			}
			if (_Products_ExFlag2 != null)
			{
				p = new SqlParameter("@Products_ExFlag2",SqlDbType.NText);
				p.Value = _Products_ExFlag2;
				rs.Add(p);
			}
			if (_Products_ExFlag3 != null)
			{
				p = new SqlParameter("@Products_ExFlag3",SqlDbType.NText);
				p.Value = _Products_ExFlag3;
				rs.Add(p);
			}
			if (_Products_ExFlag4 != null)
			{
				p = new SqlParameter("@Products_ExFlag4",SqlDbType.NText);
				p.Value = _Products_ExFlag4;
				rs.Add(p);
			}
			if (_Products_ExFlag5 != null)
			{
				p = new SqlParameter("@Products_ExFlag5",SqlDbType.NText);
				p.Value = _Products_ExFlag5;
				rs.Add(p);
			}
			if (_Products_ExFlag6 != null)
			{
				p = new SqlParameter("@Products_ExFlag6",SqlDbType.NText);
				p.Value = _Products_ExFlag6;
				rs.Add(p);
			}
			if (_Products_ExFlag7 != null)
			{
				p = new SqlParameter("@Products_ExFlag7",SqlDbType.NText);
				p.Value = _Products_ExFlag7;
				rs.Add(p);
			}
			if (_Products_ExFlag8 != null)
			{
				p = new SqlParameter("@Products_ExFlag8",SqlDbType.NText);
				p.Value = _Products_ExFlag8;
				rs.Add(p);
			}
			if (_Products_ExFlag9 != null)
			{
				p = new SqlParameter("@Products_ExFlag9",SqlDbType.NText);
				p.Value = _Products_ExFlag9;
				rs.Add(p);
			}
			if (_Products_ExFlag10 != null)
			{
				p = new SqlParameter("@Products_ExFlag10",SqlDbType.NText);
				p.Value = _Products_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ID")))
			{
				_Products_ID = (System.Int32)Rd["Products_ID"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_CateID")))
			{
				_Products_CateID = (System.Int32)Rd["Products_CateID"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_CateName")))
			{
				_Products_CateName = (System.String)Rd["Products_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_Title")))
			{
				_Products_Title = (System.String)Rd["Products_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_CodeName")))
			{
				_Products_CodeName = (System.String)Rd["Products_CodeName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_Count")))
			{
				_Products_Count = (System.Int32)Rd["Products_Count"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_Order")))
			{
				_Products_Order = (System.Int32)Rd["Products_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_State")))
			{
				_Products_State = (System.String)Rd["Products_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_AddTime")))
			{
				_Products_AddTime = (System.DateTime)Rd["Products_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_IsHot")))
			{
				_Products_IsHot = (System.String)Rd["Products_IsHot"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_IsNew")))
			{
				_Products_IsNew = (System.String)Rd["Products_IsNew"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_Prices")))
			{
				_Products_Prices = (System.String)Rd["Products_Prices"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_BigImage")))
			{
				_Products_BigImage = (System.String)Rd["Products_BigImage"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_MinImage")))
			{
				_Products_MinImage = (System.String)Rd["Products_MinImage"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_FileIntro")))
			{
				_Products_FileIntro = (System.String)Rd["Products_FileIntro"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_Introduction")))
			{
				_Products_Introduction = (System.String)Rd["Products_Introduction"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_OtherInfo")))
			{
				_Products_OtherInfo = (System.String)Rd["Products_OtherInfo"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_SEOTitle")))
			{
				_Products_SEOTitle = (System.String)Rd["Products_SEOTitle"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_SEOKeyWord")))
			{
				_Products_SEOKeyWord = (System.String)Rd["Products_SEOKeyWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_SEODescription")))
			{
				_Products_SEODescription = (System.String)Rd["Products_SEODescription"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag1")))
			{
				_Products_ExFlag1 = (System.String)Rd["Products_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag2")))
			{
				_Products_ExFlag2 = (System.String)Rd["Products_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag3")))
			{
				_Products_ExFlag3 = (System.String)Rd["Products_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag4")))
			{
				_Products_ExFlag4 = (System.String)Rd["Products_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag5")))
			{
				_Products_ExFlag5 = (System.String)Rd["Products_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag6")))
			{
				_Products_ExFlag6 = (System.String)Rd["Products_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag7")))
			{
				_Products_ExFlag7 = (System.String)Rd["Products_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag8")))
			{
				_Products_ExFlag8 = (System.String)Rd["Products_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag9")))
			{
				_Products_ExFlag9 = (System.String)Rd["Products_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Products_ExFlag10")))
			{
				_Products_ExFlag10 = (System.String)Rd["Products_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Products();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Products([Products_CateID],[Products_CateName],[Products_Title],[Products_CodeName],[Products_Count],[Products_Order],[Products_State],[Products_AddTime],[Products_IsHot],[Products_IsNew],[Products_Prices],[Products_BigImage],[Products_MinImage],[Products_FileIntro],[Products_Introduction],[Products_OtherInfo],[Products_SEOTitle],[Products_SEOKeyWord],[Products_SEODescription],[Products_ExFlag1],[Products_ExFlag2],[Products_ExFlag3],[Products_ExFlag4],[Products_ExFlag5],[Products_ExFlag6],[Products_ExFlag7],[Products_ExFlag8],[Products_ExFlag9],[Products_ExFlag10]) VALUES (@Products_CateID ,@Products_CateName ,@Products_Title ,@Products_CodeName ,@Products_Count ,@Products_Order ,@Products_State ,@Products_AddTime ,@Products_IsHot ,@Products_IsNew ,@Products_Prices ,@Products_BigImage ,@Products_MinImage ,@Products_FileIntro ,@Products_Introduction ,@Products_OtherInfo ,@Products_SEOTitle ,@Products_SEOKeyWord ,@Products_SEODescription ,@Products_ExFlag1 ,@Products_ExFlag2 ,@Products_ExFlag3 ,@Products_ExFlag4 ,@Products_ExFlag5 ,@Products_ExFlag6 ,@Products_ExFlag7 ,@Products_ExFlag8 ,@Products_ExFlag9 ,@Products_ExFlag10 )";
		}


	}

	public class Dcms_Province:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Province_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Province";
		}

		private System.Int32 _Province_Id;
		public System.Int32 Province_Id
		{
			get{ return _Province_Id; }
			set{ _Province_Id = value; }
		}
		private System.String _Province_Title;
		public System.String Province_Title
		{
			get{ return _Province_Title; }
			set{ _Province_Title = value; }
		}
		private System.String _Province_IsCenter;
		public System.String Province_IsCenter
		{
			get{ return _Province_IsCenter; }
			set{ _Province_IsCenter = value; }
		}
		private System.Int32 _Province_HasChild;
		public System.Int32 Province_HasChild
		{
			get{ return _Province_HasChild; }
			set{ _Province_HasChild = value; }
		}
		private System.Int32 _Province_ParentId;
		public System.Int32 Province_ParentId
		{
			get{ return _Province_ParentId; }
			set{ _Province_ParentId = value; }
		}
		private System.String _Province_IdPath;
		public System.String Province_IdPath
		{
			get{ return _Province_IdPath; }
			set{ _Province_IdPath = value; }
		}
		private System.Int32 _Province_Level;
		public System.Int32 Province_Level
		{
			get{ return _Province_Level; }
			set{ _Province_Level = value; }
		}
		private System.String _Province_State;
		public System.String Province_State
		{
			get{ return _Province_State; }
			set{ _Province_State = value; }
		}
		private System.String _Province_AddTime;
		public System.String Province_AddTime
		{
			get{ return _Province_AddTime; }
			set{ _Province_AddTime = value; }
		}
		private System.String _Province_ExFlag1;
		public System.String Province_ExFlag1
		{
			get{ return _Province_ExFlag1; }
			set{ _Province_ExFlag1 = value; }
		}
		private System.String _Province_ExFlag2;
		public System.String Province_ExFlag2
		{
			get{ return _Province_ExFlag2; }
			set{ _Province_ExFlag2 = value; }
		}
		private System.String _Province_ExFlag3;
		public System.String Province_ExFlag3
		{
			get{ return _Province_ExFlag3; }
			set{ _Province_ExFlag3 = value; }
		}
		private System.String _Province_ExFlag4;
		public System.String Province_ExFlag4
		{
			get{ return _Province_ExFlag4; }
			set{ _Province_ExFlag4 = value; }
		}
		private System.String _Province_ExFlag5;
		public System.String Province_ExFlag5
		{
			get{ return _Province_ExFlag5; }
			set{ _Province_ExFlag5 = value; }
		}
		private System.String _Province_ExFlag6;
		public System.String Province_ExFlag6
		{
			get{ return _Province_ExFlag6; }
			set{ _Province_ExFlag6 = value; }
		}
		private System.String _Province_ExFlag7;
		public System.String Province_ExFlag7
		{
			get{ return _Province_ExFlag7; }
			set{ _Province_ExFlag7 = value; }
		}
		private System.String _Province_ExFlag8;
		public System.String Province_ExFlag8
		{
			get{ return _Province_ExFlag8; }
			set{ _Province_ExFlag8 = value; }
		}
		private System.String _Province_ExFlag9;
		public System.String Province_ExFlag9
		{
			get{ return _Province_ExFlag9; }
			set{ _Province_ExFlag9 = value; }
		}
		private System.String _Province_ExFlag10;
		public System.String Province_ExFlag10
		{
			get{ return _Province_ExFlag10; }
			set{ _Province_ExFlag10 = value; }
		}


		public static Exp _PROVINCE_ID_ = new Exp("Province_Id");
		public static Exp _PROVINCE_TITLE_ = new Exp("Province_Title");
		public static Exp _PROVINCE_ISCENTER_ = new Exp("Province_IsCenter");
		public static Exp _PROVINCE_HASCHILD_ = new Exp("Province_HasChild");
		public static Exp _PROVINCE_PARENTID_ = new Exp("Province_ParentId");
		public static Exp _PROVINCE_IDPATH_ = new Exp("Province_IdPath");
		public static Exp _PROVINCE_LEVEL_ = new Exp("Province_Level");
		public static Exp _PROVINCE_STATE_ = new Exp("Province_State");
		public static Exp _PROVINCE_ADDTIME_ = new Exp("Province_AddTime");
		public static Exp _PROVINCE_EXFLAG1_ = new Exp("Province_ExFlag1");
		public static Exp _PROVINCE_EXFLAG2_ = new Exp("Province_ExFlag2");
		public static Exp _PROVINCE_EXFLAG3_ = new Exp("Province_ExFlag3");
		public static Exp _PROVINCE_EXFLAG4_ = new Exp("Province_ExFlag4");
		public static Exp _PROVINCE_EXFLAG5_ = new Exp("Province_ExFlag5");
		public static Exp _PROVINCE_EXFLAG6_ = new Exp("Province_ExFlag6");
		public static Exp _PROVINCE_EXFLAG7_ = new Exp("Province_ExFlag7");
		public static Exp _PROVINCE_EXFLAG8_ = new Exp("Province_ExFlag8");
		public static Exp _PROVINCE_EXFLAG9_ = new Exp("Province_ExFlag9");
		public static Exp _PROVINCE_EXFLAG10_ = new Exp("Province_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Province_Id",SqlDbType.Int);
			p.Value = _Province_Id;
			rs.Add(p);
			if (_Province_Title != null)
			{
				p = new SqlParameter("@Province_Title",SqlDbType.NVarChar);
				p.Value = _Province_Title;
				rs.Add(p);
			}
			if (_Province_IsCenter != null)
			{
				p = new SqlParameter("@Province_IsCenter",SqlDbType.NVarChar);
				p.Value = _Province_IsCenter;
				rs.Add(p);
			}
			p = new SqlParameter("@Province_HasChild",SqlDbType.Int);
			p.Value = _Province_HasChild;
			rs.Add(p);
			p = new SqlParameter("@Province_ParentId",SqlDbType.Int);
			p.Value = _Province_ParentId;
			rs.Add(p);
			if (_Province_IdPath != null)
			{
				p = new SqlParameter("@Province_IdPath",SqlDbType.NVarChar);
				p.Value = _Province_IdPath;
				rs.Add(p);
			}
			p = new SqlParameter("@Province_Level",SqlDbType.Int);
			p.Value = _Province_Level;
			rs.Add(p);
			if (_Province_State != null)
			{
				p = new SqlParameter("@Province_State",SqlDbType.NVarChar);
				p.Value = _Province_State;
				rs.Add(p);
			}
			if (_Province_AddTime != null)
			{
				p = new SqlParameter("@Province_AddTime",SqlDbType.NVarChar);
				p.Value = _Province_AddTime;
				rs.Add(p);
			}
			if (_Province_ExFlag1 != null)
			{
				p = new SqlParameter("@Province_ExFlag1",SqlDbType.Text);
				p.Value = _Province_ExFlag1;
				rs.Add(p);
			}
			if (_Province_ExFlag2 != null)
			{
				p = new SqlParameter("@Province_ExFlag2",SqlDbType.Text);
				p.Value = _Province_ExFlag2;
				rs.Add(p);
			}
			if (_Province_ExFlag3 != null)
			{
				p = new SqlParameter("@Province_ExFlag3",SqlDbType.Text);
				p.Value = _Province_ExFlag3;
				rs.Add(p);
			}
			if (_Province_ExFlag4 != null)
			{
				p = new SqlParameter("@Province_ExFlag4",SqlDbType.Text);
				p.Value = _Province_ExFlag4;
				rs.Add(p);
			}
			if (_Province_ExFlag5 != null)
			{
				p = new SqlParameter("@Province_ExFlag5",SqlDbType.Text);
				p.Value = _Province_ExFlag5;
				rs.Add(p);
			}
			if (_Province_ExFlag6 != null)
			{
				p = new SqlParameter("@Province_ExFlag6",SqlDbType.Text);
				p.Value = _Province_ExFlag6;
				rs.Add(p);
			}
			if (_Province_ExFlag7 != null)
			{
				p = new SqlParameter("@Province_ExFlag7",SqlDbType.Text);
				p.Value = _Province_ExFlag7;
				rs.Add(p);
			}
			if (_Province_ExFlag8 != null)
			{
				p = new SqlParameter("@Province_ExFlag8",SqlDbType.Text);
				p.Value = _Province_ExFlag8;
				rs.Add(p);
			}
			if (_Province_ExFlag9 != null)
			{
				p = new SqlParameter("@Province_ExFlag9",SqlDbType.Text);
				p.Value = _Province_ExFlag9;
				rs.Add(p);
			}
			if (_Province_ExFlag10 != null)
			{
				p = new SqlParameter("@Province_ExFlag10",SqlDbType.Text);
				p.Value = _Province_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_Id")))
			{
				_Province_Id = (System.Int32)Rd["Province_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_Title")))
			{
				_Province_Title = (System.String)Rd["Province_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_IsCenter")))
			{
				_Province_IsCenter = (System.String)Rd["Province_IsCenter"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_HasChild")))
			{
				_Province_HasChild = (System.Int32)Rd["Province_HasChild"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ParentId")))
			{
				_Province_ParentId = (System.Int32)Rd["Province_ParentId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_IdPath")))
			{
				_Province_IdPath = (System.String)Rd["Province_IdPath"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_Level")))
			{
				_Province_Level = (System.Int32)Rd["Province_Level"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_State")))
			{
				_Province_State = (System.String)Rd["Province_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_AddTime")))
			{
				_Province_AddTime = (System.String)Rd["Province_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag1")))
			{
				_Province_ExFlag1 = (System.String)Rd["Province_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag2")))
			{
				_Province_ExFlag2 = (System.String)Rd["Province_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag3")))
			{
				_Province_ExFlag3 = (System.String)Rd["Province_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag4")))
			{
				_Province_ExFlag4 = (System.String)Rd["Province_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag5")))
			{
				_Province_ExFlag5 = (System.String)Rd["Province_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag6")))
			{
				_Province_ExFlag6 = (System.String)Rd["Province_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag7")))
			{
				_Province_ExFlag7 = (System.String)Rd["Province_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag8")))
			{
				_Province_ExFlag8 = (System.String)Rd["Province_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag9")))
			{
				_Province_ExFlag9 = (System.String)Rd["Province_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Province_ExFlag10")))
			{
				_Province_ExFlag10 = (System.String)Rd["Province_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Province();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Province([Province_Title],[Province_IsCenter],[Province_HasChild],[Province_ParentId],[Province_IdPath],[Province_Level],[Province_State],[Province_AddTime],[Province_ExFlag1],[Province_ExFlag2],[Province_ExFlag3],[Province_ExFlag4],[Province_ExFlag5],[Province_ExFlag6],[Province_ExFlag7],[Province_ExFlag8],[Province_ExFlag9],[Province_ExFlag10]) VALUES (@Province_Title ,@Province_IsCenter ,@Province_HasChild ,@Province_ParentId ,@Province_IdPath ,@Province_Level ,@Province_State ,@Province_AddTime ,@Province_ExFlag1 ,@Province_ExFlag2 ,@Province_ExFlag3 ,@Province_ExFlag4 ,@Province_ExFlag5 ,@Province_ExFlag6 ,@Province_ExFlag7 ,@Province_ExFlag8 ,@Province_ExFlag9 ,@Province_ExFlag10 )";
		}


	}

	public class Dcms_QMenu:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "QMenu_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_QMenu";
		}

		private System.Int32 _QMenu_Id;
		public System.Int32 QMenu_Id
		{
			get{ return _QMenu_Id; }
			set{ _QMenu_Id = value; }
		}
		private System.String _QMenu_Title;
		public System.String QMenu_Title
		{
			get{ return _QMenu_Title; }
			set{ _QMenu_Title = value; }
		}
		private System.String _QMenu_Url;
		public System.String QMenu_Url
		{
			get{ return _QMenu_Url; }
			set{ _QMenu_Url = value; }
		}
		private System.Int32 _QMenu_AdminId;
		public System.Int32 QMenu_AdminId
		{
			get{ return _QMenu_AdminId; }
			set{ _QMenu_AdminId = value; }
		}
		private System.Int32 _QMenu_Order;
		public System.Int32 QMenu_Order
		{
			get{ return _QMenu_Order; }
			set{ _QMenu_Order = value; }
		}


		public static Exp _QMENU_ID_ = new Exp("QMenu_Id");
		public static Exp _QMENU_TITLE_ = new Exp("QMenu_Title");
		public static Exp _QMENU_URL_ = new Exp("QMenu_Url");
		public static Exp _QMENU_ADMINID_ = new Exp("QMenu_AdminId");
		public static Exp _QMENU_ORDER_ = new Exp("QMenu_Order");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@QMenu_Id",SqlDbType.Int);
			p.Value = _QMenu_Id;
			rs.Add(p);
			if (_QMenu_Title != null)
			{
				p = new SqlParameter("@QMenu_Title",SqlDbType.VarChar);
				p.Value = _QMenu_Title;
				rs.Add(p);
			}
			if (_QMenu_Url != null)
			{
				p = new SqlParameter("@QMenu_Url",SqlDbType.NVarChar);
				p.Value = _QMenu_Url;
				rs.Add(p);
			}
			p = new SqlParameter("@QMenu_AdminId",SqlDbType.Int);
			p.Value = _QMenu_AdminId;
			rs.Add(p);
			p = new SqlParameter("@QMenu_Order",SqlDbType.Int);
			p.Value = _QMenu_Order;
			rs.Add(p);
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("QMenu_Id")))
			{
				_QMenu_Id = (System.Int32)Rd["QMenu_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("QMenu_Title")))
			{
				_QMenu_Title = (System.String)Rd["QMenu_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("QMenu_Url")))
			{
				_QMenu_Url = (System.String)Rd["QMenu_Url"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("QMenu_AdminId")))
			{
				_QMenu_AdminId = (System.Int32)Rd["QMenu_AdminId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("QMenu_Order")))
			{
				_QMenu_Order = (System.Int32)Rd["QMenu_Order"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_QMenu();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_QMenu([QMenu_Title],[QMenu_Url],[QMenu_AdminId],[QMenu_Order]) VALUES (@QMenu_Title ,@QMenu_Url ,@QMenu_AdminId ,@QMenu_Order )";
		}


	}

	public class Dcms_Role:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Role_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_Role";
		}

		private System.Int32 _Role_Id;
		public System.Int32 Role_Id
		{
			get{ return _Role_Id; }
			set{ _Role_Id = value; }
		}
		private System.String _Role_Name;
		public System.String Role_Name
		{
			get{ return _Role_Name; }
			set{ _Role_Name = value; }
		}
		private System.Int32 _Role_Order;
		public System.Int32 Role_Order
		{
			get{ return _Role_Order; }
			set{ _Role_Order = value; }
		}
		private System.DateTime _Role_AddTime;
		public System.DateTime Role_AddTime
		{
			get{ return _Role_AddTime; }
			set{ _Role_AddTime = value; }
		}
		private System.String _Role_CateLang;
		public System.String Role_CateLang
		{
			get{ return _Role_CateLang; }
			set{ _Role_CateLang = value; }
		}


		public static Exp _ROLE_ID_ = new Exp("Role_Id");
		public static Exp _ROLE_NAME_ = new Exp("Role_Name");
		public static Exp _ROLE_ORDER_ = new Exp("Role_Order");
		public static Exp _ROLE_ADDTIME_ = new Exp("Role_AddTime");
		public static Exp _ROLE_CATELANG_ = new Exp("Role_CateLang");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Role_Id",SqlDbType.Int);
			p.Value = _Role_Id;
			rs.Add(p);
			if (_Role_Name != null)
			{
				p = new SqlParameter("@Role_Name",SqlDbType.NVarChar);
				p.Value = _Role_Name;
				rs.Add(p);
			}
			p = new SqlParameter("@Role_Order",SqlDbType.Int);
			p.Value = _Role_Order;
			rs.Add(p);
			if (_Role_AddTime != null)
			{
				if (_Role_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@Role_AddTime",SqlDbType.SmallDateTime);
					p.Value = _Role_AddTime;
					rs.Add(p);
				}
			}
			if (_Role_CateLang != null)
			{
				p = new SqlParameter("@Role_CateLang",SqlDbType.VarChar);
				p.Value = _Role_CateLang;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Role_Id")))
			{
				_Role_Id = (System.Int32)Rd["Role_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Role_Name")))
			{
				_Role_Name = (System.String)Rd["Role_Name"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Role_Order")))
			{
				_Role_Order = (System.Int32)Rd["Role_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Role_AddTime")))
			{
				_Role_AddTime = (System.DateTime)Rd["Role_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Role_CateLang")))
			{
				_Role_CateLang = (System.String)Rd["Role_CateLang"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_Role();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_Role([Role_Name],[Role_Order],[Role_AddTime],[Role_CateLang]) VALUES (@Role_Name ,@Role_Order ,@Role_AddTime ,@Role_CateLang )";
		}


	}

	public class Dcms_SaleNet:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "SaleNet_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_SaleNet";
		}

		private System.Int32 _SaleNet_Id;
		public System.Int32 SaleNet_Id
		{
			get{ return _SaleNet_Id; }
			set{ _SaleNet_Id = value; }
		}
		private System.Int32 _SaleNet_CateId;
		public System.Int32 SaleNet_CateId
		{
			get{ return _SaleNet_CateId; }
			set{ _SaleNet_CateId = value; }
		}
		private System.String _SaleNet_CateName;
		public System.String SaleNet_CateName
		{
			get{ return _SaleNet_CateName; }
			set{ _SaleNet_CateName = value; }
		}
		private System.String _SaleNet_Title;
		public System.String SaleNet_Title
		{
			get{ return _SaleNet_Title; }
			set{ _SaleNet_Title = value; }
		}
		private System.String _SaleNet_Province;
		public System.String SaleNet_Province
		{
			get{ return _SaleNet_Province; }
			set{ _SaleNet_Province = value; }
		}
		private System.DateTime _SaleNet_AddTime;
		public System.DateTime SaleNet_AddTime
		{
			get{ return _SaleNet_AddTime; }
			set{ _SaleNet_AddTime = value; }
		}
		private System.Int32 _SaleNet_Order;
		public System.Int32 SaleNet_Order
		{
			get{ return _SaleNet_Order; }
			set{ _SaleNet_Order = value; }
		}
		private System.String _SaleNet_State;
		public System.String SaleNet_State
		{
			get{ return _SaleNet_State; }
			set{ _SaleNet_State = value; }
		}
		private System.String _SaleNet_Content;
		public System.String SaleNet_Content
		{
			get{ return _SaleNet_Content; }
			set{ _SaleNet_Content = value; }
		}
		private System.String _SaleNet_ExFlag1;
		public System.String SaleNet_ExFlag1
		{
			get{ return _SaleNet_ExFlag1; }
			set{ _SaleNet_ExFlag1 = value; }
		}
		private System.String _SaleNet_ExFlag2;
		public System.String SaleNet_ExFlag2
		{
			get{ return _SaleNet_ExFlag2; }
			set{ _SaleNet_ExFlag2 = value; }
		}
		private System.String _SaleNet_ExFlag3;
		public System.String SaleNet_ExFlag3
		{
			get{ return _SaleNet_ExFlag3; }
			set{ _SaleNet_ExFlag3 = value; }
		}
		private System.String _SaleNet_ExFlag4;
		public System.String SaleNet_ExFlag4
		{
			get{ return _SaleNet_ExFlag4; }
			set{ _SaleNet_ExFlag4 = value; }
		}
		private System.String _SaleNet_ExFlag5;
		public System.String SaleNet_ExFlag5
		{
			get{ return _SaleNet_ExFlag5; }
			set{ _SaleNet_ExFlag5 = value; }
		}
		private System.String _SaleNet_ExFlag6;
		public System.String SaleNet_ExFlag6
		{
			get{ return _SaleNet_ExFlag6; }
			set{ _SaleNet_ExFlag6 = value; }
		}
		private System.String _SaleNet_ExFlag7;
		public System.String SaleNet_ExFlag7
		{
			get{ return _SaleNet_ExFlag7; }
			set{ _SaleNet_ExFlag7 = value; }
		}
		private System.String _SaleNet_ExFlag8;
		public System.String SaleNet_ExFlag8
		{
			get{ return _SaleNet_ExFlag8; }
			set{ _SaleNet_ExFlag8 = value; }
		}
		private System.String _SaleNet_ExFlag9;
		public System.String SaleNet_ExFlag9
		{
			get{ return _SaleNet_ExFlag9; }
			set{ _SaleNet_ExFlag9 = value; }
		}
		private System.String _SaleNet_ExFlag10;
		public System.String SaleNet_ExFlag10
		{
			get{ return _SaleNet_ExFlag10; }
			set{ _SaleNet_ExFlag10 = value; }
		}


		public static Exp _SALENET_ID_ = new Exp("SaleNet_Id");
		public static Exp _SALENET_CATEID_ = new Exp("SaleNet_CateId");
		public static Exp _SALENET_CATENAME_ = new Exp("SaleNet_CateName");
		public static Exp _SALENET_TITLE_ = new Exp("SaleNet_Title");
		public static Exp _SALENET_PROVINCE_ = new Exp("SaleNet_Province");
		public static Exp _SALENET_ADDTIME_ = new Exp("SaleNet_AddTime");
		public static Exp _SALENET_ORDER_ = new Exp("SaleNet_Order");
		public static Exp _SALENET_STATE_ = new Exp("SaleNet_State");
		public static Exp _SALENET_CONTENT_ = new Exp("SaleNet_Content");
		public static Exp _SALENET_EXFLAG1_ = new Exp("SaleNet_ExFlag1");
		public static Exp _SALENET_EXFLAG2_ = new Exp("SaleNet_ExFlag2");
		public static Exp _SALENET_EXFLAG3_ = new Exp("SaleNet_ExFlag3");
		public static Exp _SALENET_EXFLAG4_ = new Exp("SaleNet_ExFlag4");
		public static Exp _SALENET_EXFLAG5_ = new Exp("SaleNet_ExFlag5");
		public static Exp _SALENET_EXFLAG6_ = new Exp("SaleNet_ExFlag6");
		public static Exp _SALENET_EXFLAG7_ = new Exp("SaleNet_ExFlag7");
		public static Exp _SALENET_EXFLAG8_ = new Exp("SaleNet_ExFlag8");
		public static Exp _SALENET_EXFLAG9_ = new Exp("SaleNet_ExFlag9");
		public static Exp _SALENET_EXFLAG10_ = new Exp("SaleNet_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@SaleNet_Id",SqlDbType.Int);
			p.Value = _SaleNet_Id;
			rs.Add(p);
			p = new SqlParameter("@SaleNet_CateId",SqlDbType.Int);
			p.Value = _SaleNet_CateId;
			rs.Add(p);
			if (_SaleNet_CateName != null)
			{
				p = new SqlParameter("@SaleNet_CateName",SqlDbType.NVarChar);
				p.Value = _SaleNet_CateName;
				rs.Add(p);
			}
			if (_SaleNet_Title != null)
			{
				p = new SqlParameter("@SaleNet_Title",SqlDbType.NVarChar);
				p.Value = _SaleNet_Title;
				rs.Add(p);
			}
			if (_SaleNet_Province != null)
			{
				p = new SqlParameter("@SaleNet_Province",SqlDbType.NVarChar);
				p.Value = _SaleNet_Province;
				rs.Add(p);
			}
			if (_SaleNet_AddTime != null)
			{
				if (_SaleNet_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@SaleNet_AddTime",SqlDbType.DateTime);
					p.Value = _SaleNet_AddTime;
					rs.Add(p);
				}
			}
			p = new SqlParameter("@SaleNet_Order",SqlDbType.Int);
			p.Value = _SaleNet_Order;
			rs.Add(p);
			if (_SaleNet_State != null)
			{
				p = new SqlParameter("@SaleNet_State",SqlDbType.NVarChar);
				p.Value = _SaleNet_State;
				rs.Add(p);
			}
			if (_SaleNet_Content != null)
			{
				p = new SqlParameter("@SaleNet_Content",SqlDbType.Text);
				p.Value = _SaleNet_Content;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag1 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag1",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag1;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag2 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag2",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag2;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag3 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag3",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag3;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag4 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag4",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag4;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag5 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag5",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag5;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag6 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag6",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag6;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag7 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag7",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag7;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag8 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag8",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag8;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag9 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag9",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag9;
				rs.Add(p);
			}
			if (_SaleNet_ExFlag10 != null)
			{
				p = new SqlParameter("@SaleNet_ExFlag10",SqlDbType.Text);
				p.Value = _SaleNet_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_Id")))
			{
				_SaleNet_Id = (System.Int32)Rd["SaleNet_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_CateId")))
			{
				_SaleNet_CateId = (System.Int32)Rd["SaleNet_CateId"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_CateName")))
			{
				_SaleNet_CateName = (System.String)Rd["SaleNet_CateName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_Title")))
			{
				_SaleNet_Title = (System.String)Rd["SaleNet_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_Province")))
			{
				_SaleNet_Province = (System.String)Rd["SaleNet_Province"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_AddTime")))
			{
				_SaleNet_AddTime = (System.DateTime)Rd["SaleNet_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_Order")))
			{
				_SaleNet_Order = (System.Int32)Rd["SaleNet_Order"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_State")))
			{
				_SaleNet_State = (System.String)Rd["SaleNet_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_Content")))
			{
				_SaleNet_Content = (System.String)Rd["SaleNet_Content"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag1")))
			{
				_SaleNet_ExFlag1 = (System.String)Rd["SaleNet_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag2")))
			{
				_SaleNet_ExFlag2 = (System.String)Rd["SaleNet_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag3")))
			{
				_SaleNet_ExFlag3 = (System.String)Rd["SaleNet_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag4")))
			{
				_SaleNet_ExFlag4 = (System.String)Rd["SaleNet_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag5")))
			{
				_SaleNet_ExFlag5 = (System.String)Rd["SaleNet_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag6")))
			{
				_SaleNet_ExFlag6 = (System.String)Rd["SaleNet_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag7")))
			{
				_SaleNet_ExFlag7 = (System.String)Rd["SaleNet_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag8")))
			{
				_SaleNet_ExFlag8 = (System.String)Rd["SaleNet_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag9")))
			{
				_SaleNet_ExFlag9 = (System.String)Rd["SaleNet_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SaleNet_ExFlag10")))
			{
				_SaleNet_ExFlag10 = (System.String)Rd["SaleNet_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_SaleNet();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_SaleNet([SaleNet_CateId],[SaleNet_CateName],[SaleNet_Title],[SaleNet_Province],[SaleNet_AddTime],[SaleNet_Order],[SaleNet_State],[SaleNet_Content],[SaleNet_ExFlag1],[SaleNet_ExFlag2],[SaleNet_ExFlag3],[SaleNet_ExFlag4],[SaleNet_ExFlag5],[SaleNet_ExFlag6],[SaleNet_ExFlag7],[SaleNet_ExFlag8],[SaleNet_ExFlag9],[SaleNet_ExFlag10]) VALUES (@SaleNet_CateId ,@SaleNet_CateName ,@SaleNet_Title ,@SaleNet_Province ,@SaleNet_AddTime ,@SaleNet_Order ,@SaleNet_State ,@SaleNet_Content ,@SaleNet_ExFlag1 ,@SaleNet_ExFlag2 ,@SaleNet_ExFlag3 ,@SaleNet_ExFlag4 ,@SaleNet_ExFlag5 ,@SaleNet_ExFlag6 ,@SaleNet_ExFlag7 ,@SaleNet_ExFlag8 ,@SaleNet_ExFlag9 ,@SaleNet_ExFlag10 )";
		}


	}

	public class Dcms_SysCate:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "SysCate_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_SysCate";
		}

		private System.Int32 _SysCate_Id;
		public System.Int32 SysCate_Id
		{
			get{ return _SysCate_Id; }
			set{ _SysCate_Id = value; }
		}
		private System.String _SysCate_Name;
		public System.String SysCate_Name
		{
			get{ return _SysCate_Name; }
			set{ _SysCate_Name = value; }
		}
		private System.String _SysCate_Url;
		public System.String SysCate_Url
		{
			get{ return _SysCate_Url; }
			set{ _SysCate_Url = value; }
		}
		private System.Int32 _SysCate_Type;
		public System.Int32 SysCate_Type
		{
			get{ return _SysCate_Type; }
			set{ _SysCate_Type = value; }
		}
		private System.Int32 _SysCate_Order;
		public System.Int32 SysCate_Order
		{
			get{ return _SysCate_Order; }
			set{ _SysCate_Order = value; }
		}


		public static Exp _SYSCATE_ID_ = new Exp("SysCate_Id");
		public static Exp _SYSCATE_NAME_ = new Exp("SysCate_Name");
		public static Exp _SYSCATE_URL_ = new Exp("SysCate_Url");
		public static Exp _SYSCATE_TYPE_ = new Exp("SysCate_Type");
		public static Exp _SYSCATE_ORDER_ = new Exp("SysCate_Order");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@SysCate_Id",SqlDbType.Int);
			p.Value = _SysCate_Id;
			rs.Add(p);
			if (_SysCate_Name != null)
			{
				p = new SqlParameter("@SysCate_Name",SqlDbType.NVarChar);
				p.Value = _SysCate_Name;
				rs.Add(p);
			}
			if (_SysCate_Url != null)
			{
				p = new SqlParameter("@SysCate_Url",SqlDbType.NVarChar);
				p.Value = _SysCate_Url;
				rs.Add(p);
			}
			p = new SqlParameter("@SysCate_Type",SqlDbType.Int);
			p.Value = _SysCate_Type;
			rs.Add(p);
			p = new SqlParameter("@SysCate_Order",SqlDbType.Int);
			p.Value = _SysCate_Order;
			rs.Add(p);
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("SysCate_Id")))
			{
				_SysCate_Id = (System.Int32)Rd["SysCate_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SysCate_Name")))
			{
				_SysCate_Name = (System.String)Rd["SysCate_Name"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SysCate_Url")))
			{
				_SysCate_Url = (System.String)Rd["SysCate_Url"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SysCate_Type")))
			{
				_SysCate_Type = (System.Int32)Rd["SysCate_Type"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("SysCate_Order")))
			{
				_SysCate_Order = (System.Int32)Rd["SysCate_Order"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_SysCate();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_SysCate([SysCate_Name],[SysCate_Url],[SysCate_Type],[SysCate_Order]) VALUES (@SysCate_Name ,@SysCate_Url ,@SysCate_Type ,@SysCate_Order )";
		}


	}

	public class Dcms_TempLate:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "Template_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_TempLate";
		}

		private System.Int32 _Template_Id;
		public System.Int32 Template_Id
		{
			get{ return _Template_Id; }
			set{ _Template_Id = value; }
		}
		private System.String _Template_Directory;
		public System.String Template_Directory
		{
			get{ return _Template_Directory; }
			set{ _Template_Directory = value; }
		}
		private System.String _Template_Name;
		public System.String Template_Name
		{
			get{ return _Template_Name; }
			set{ _Template_Name = value; }
		}
		private System.String _Template_Author;
		public System.String Template_Author
		{
			get{ return _Template_Author; }
			set{ _Template_Author = value; }
		}
		private System.String _Template_CreateTime;
		public System.String Template_CreateTime
		{
			get{ return _Template_CreateTime; }
			set{ _Template_CreateTime = value; }
		}
		private System.String _Template_UpdateTime;
		public System.String Template_UpdateTime
		{
			get{ return _Template_UpdateTime; }
			set{ _Template_UpdateTime = value; }
		}
		private System.Int32 _Template_State;
		public System.Int32 Template_State
		{
			get{ return _Template_State; }
			set{ _Template_State = value; }
		}
		private System.String _Template_Ver;
		public System.String Template_Ver
		{
			get{ return _Template_Ver; }
			set{ _Template_Ver = value; }
		}
		private System.String _Template_Fordntver;
		public System.String Template_Fordntver
		{
			get{ return _Template_Fordntver; }
			set{ _Template_Fordntver = value; }
		}
		private System.String _Template_Copyright;
		public System.String Template_Copyright
		{
			get{ return _Template_Copyright; }
			set{ _Template_Copyright = value; }
		}


		public static Exp _TEMPLATE_ID_ = new Exp("Template_Id");
		public static Exp _TEMPLATE_DIRECTORY_ = new Exp("Template_Directory");
		public static Exp _TEMPLATE_NAME_ = new Exp("Template_Name");
		public static Exp _TEMPLATE_AUTHOR_ = new Exp("Template_Author");
		public static Exp _TEMPLATE_CREATETIME_ = new Exp("Template_CreateTime");
		public static Exp _TEMPLATE_UPDATETIME_ = new Exp("Template_UpdateTime");
		public static Exp _TEMPLATE_STATE_ = new Exp("Template_State");
		public static Exp _TEMPLATE_VER_ = new Exp("Template_Ver");
		public static Exp _TEMPLATE_FORDNTVER_ = new Exp("Template_Fordntver");
		public static Exp _TEMPLATE_COPYRIGHT_ = new Exp("Template_Copyright");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@Template_Id",SqlDbType.Int);
			p.Value = _Template_Id;
			rs.Add(p);
			if (_Template_Directory != null)
			{
				p = new SqlParameter("@Template_Directory",SqlDbType.VarChar);
				p.Value = _Template_Directory;
				rs.Add(p);
			}
			if (_Template_Name != null)
			{
				p = new SqlParameter("@Template_Name",SqlDbType.VarChar);
				p.Value = _Template_Name;
				rs.Add(p);
			}
			if (_Template_Author != null)
			{
				p = new SqlParameter("@Template_Author",SqlDbType.VarChar);
				p.Value = _Template_Author;
				rs.Add(p);
			}
			if (_Template_CreateTime != null)
			{
				p = new SqlParameter("@Template_CreateTime",SqlDbType.VarChar);
				p.Value = _Template_CreateTime;
				rs.Add(p);
			}
			if (_Template_UpdateTime != null)
			{
				p = new SqlParameter("@Template_UpdateTime",SqlDbType.VarChar);
				p.Value = _Template_UpdateTime;
				rs.Add(p);
			}
			p = new SqlParameter("@Template_State",SqlDbType.Int);
			p.Value = _Template_State;
			rs.Add(p);
			if (_Template_Ver != null)
			{
				p = new SqlParameter("@Template_Ver",SqlDbType.VarChar);
				p.Value = _Template_Ver;
				rs.Add(p);
			}
			if (_Template_Fordntver != null)
			{
				p = new SqlParameter("@Template_Fordntver",SqlDbType.VarChar);
				p.Value = _Template_Fordntver;
				rs.Add(p);
			}
			if (_Template_Copyright != null)
			{
				p = new SqlParameter("@Template_Copyright",SqlDbType.VarChar);
				p.Value = _Template_Copyright;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Id")))
			{
				_Template_Id = (System.Int32)Rd["Template_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Directory")))
			{
				_Template_Directory = (System.String)Rd["Template_Directory"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Name")))
			{
				_Template_Name = (System.String)Rd["Template_Name"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Author")))
			{
				_Template_Author = (System.String)Rd["Template_Author"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_CreateTime")))
			{
				_Template_CreateTime = (System.String)Rd["Template_CreateTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_UpdateTime")))
			{
				_Template_UpdateTime = (System.String)Rd["Template_UpdateTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_State")))
			{
				_Template_State = (System.Int32)Rd["Template_State"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Ver")))
			{
				_Template_Ver = (System.String)Rd["Template_Ver"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Fordntver")))
			{
				_Template_Fordntver = (System.String)Rd["Template_Fordntver"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("Template_Copyright")))
			{
				_Template_Copyright = (System.String)Rd["Template_Copyright"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_TempLate();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_TempLate([Template_Directory],[Template_Name],[Template_Author],[Template_CreateTime],[Template_UpdateTime],[Template_State],[Template_Ver],[Template_Fordntver],[Template_Copyright]) VALUES (@Template_Directory ,@Template_Name ,@Template_Author ,@Template_CreateTime ,@Template_UpdateTime ,@Template_State ,@Template_Ver ,@Template_Fordntver ,@Template_Copyright )";
		}


	}

	public class Dcms_User:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "User_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_User";
		}

		private System.Int32 _User_Id;
		public System.Int32 User_Id
		{
			get{ return _User_Id; }
			set{ _User_Id = value; }
		}
		private System.String _User_Name;
		public System.String User_Name
		{
			get{ return _User_Name; }
			set{ _User_Name = value; }
		}
		private System.String _User_RealName;
		public System.String User_RealName
		{
			get{ return _User_RealName; }
			set{ _User_RealName = value; }
		}
		private System.String _User_PassWord;
		public System.String User_PassWord
		{
			get{ return _User_PassWord; }
			set{ _User_PassWord = value; }
		}
		private System.String _User_Email;
		public System.String User_Email
		{
			get{ return _User_Email; }
			set{ _User_Email = value; }
		}
		private System.String _User_Gender;
		public System.String User_Gender
		{
			get{ return _User_Gender; }
			set{ _User_Gender = value; }
		}
		private System.String _User_LevelKey;
		public System.String User_LevelKey
		{
			get{ return _User_LevelKey; }
			set{ _User_LevelKey = value; }
		}
		private System.String _User_RegIp;
		public System.String User_RegIp
		{
			get{ return _User_RegIp; }
			set{ _User_RegIp = value; }
		}
		private System.String _User_Avatar;
		public System.String User_Avatar
		{
			get{ return _User_Avatar; }
			set{ _User_Avatar = value; }
		}
		private System.DateTime _User_RegTime;
		public System.DateTime User_RegTime
		{
			get{ return _User_RegTime; }
			set{ _User_RegTime = value; }
		}
		private System.String _User_LastIp;
		public System.String User_LastIp
		{
			get{ return _User_LastIp; }
			set{ _User_LastIp = value; }
		}
		private System.DateTime _User_LastTime;
		public System.DateTime User_LastTime
		{
			get{ return _User_LastTime; }
			set{ _User_LastTime = value; }
		}
		private System.Int32 _User_Credits;
		public System.Int32 User_Credits
		{
			get{ return _User_Credits; }
			set{ _User_Credits = value; }
		}
		private System.Int32 _User_PMSound;
		public System.Int32 User_PMSound
		{
			get{ return _User_PMSound; }
			set{ _User_PMSound = value; }
		}
		private System.Int32 _User_InVisible;
		public System.Int32 User_InVisible
		{
			get{ return _User_InVisible; }
			set{ _User_InVisible = value; }
		}
		private System.Int32 _User_NewPM;
		public System.Int32 User_NewPM
		{
			get{ return _User_NewPM; }
			set{ _User_NewPM = value; }
		}
		private System.Int32 _User_NewPMCcount;
		public System.Int32 User_NewPMCcount
		{
			get{ return _User_NewPMCcount; }
			set{ _User_NewPMCcount = value; }
		}
		private System.Int32 _User_OnlineState;
		public System.Int32 User_OnlineState
		{
			get{ return _User_OnlineState; }
			set{ _User_OnlineState = value; }
		}
		private System.DateTime _User_BirthDay;
		public System.DateTime User_BirthDay
		{
			get{ return _User_BirthDay; }
			set{ _User_BirthDay = value; }
		}
		private System.String _User_Sign;
		public System.String User_Sign
		{
			get{ return _User_Sign; }
			set{ _User_Sign = value; }
		}
		private System.String _User_Address;
		public System.String User_Address
		{
			get{ return _User_Address; }
			set{ _User_Address = value; }
		}
		private System.String _User_PostCode;
		public System.String User_PostCode
		{
			get{ return _User_PostCode; }
			set{ _User_PostCode = value; }
		}
		private System.String _User_Company;
		public System.String User_Company
		{
			get{ return _User_Company; }
			set{ _User_Company = value; }
		}
		private System.String _User_Job;
		public System.String User_Job
		{
			get{ return _User_Job; }
			set{ _User_Job = value; }
		}
		private System.String _User_City;
		public System.String User_City
		{
			get{ return _User_City; }
			set{ _User_City = value; }
		}
		private System.String _User_IM;
		public System.String User_IM
		{
			get{ return _User_IM; }
			set{ _User_IM = value; }
		}
		private System.String _User_Tel;
		public System.String User_Tel
		{
			get{ return _User_Tel; }
			set{ _User_Tel = value; }
		}
		private System.String _User_Country;
		public System.String User_Country
		{
			get{ return _User_Country; }
			set{ _User_Country = value; }
		}
		private System.String _User_ExFlag1;
		public System.String User_ExFlag1
		{
			get{ return _User_ExFlag1; }
			set{ _User_ExFlag1 = value; }
		}
		private System.String _User_ExFlag2;
		public System.String User_ExFlag2
		{
			get{ return _User_ExFlag2; }
			set{ _User_ExFlag2 = value; }
		}
		private System.String _User_ExFlag3;
		public System.String User_ExFlag3
		{
			get{ return _User_ExFlag3; }
			set{ _User_ExFlag3 = value; }
		}
		private System.String _User_ExFlag4;
		public System.String User_ExFlag4
		{
			get{ return _User_ExFlag4; }
			set{ _User_ExFlag4 = value; }
		}
		private System.String _User_ExFlag5;
		public System.String User_ExFlag5
		{
			get{ return _User_ExFlag5; }
			set{ _User_ExFlag5 = value; }
		}
		private System.String _User_ExFlag6;
		public System.String User_ExFlag6
		{
			get{ return _User_ExFlag6; }
			set{ _User_ExFlag6 = value; }
		}
		private System.String _User_ExFlag7;
		public System.String User_ExFlag7
		{
			get{ return _User_ExFlag7; }
			set{ _User_ExFlag7 = value; }
		}
		private System.String _User_ExFlag8;
		public System.String User_ExFlag8
		{
			get{ return _User_ExFlag8; }
			set{ _User_ExFlag8 = value; }
		}
		private System.String _User_ExFlag9;
		public System.String User_ExFlag9
		{
			get{ return _User_ExFlag9; }
			set{ _User_ExFlag9 = value; }
		}
		private System.String _User_ExFlag10;
		public System.String User_ExFlag10
		{
			get{ return _User_ExFlag10; }
			set{ _User_ExFlag10 = value; }
		}


		public static Exp _USER_ID_ = new Exp("User_Id");
		public static Exp _USER_NAME_ = new Exp("User_Name");
		public static Exp _USER_REALNAME_ = new Exp("User_RealName");
		public static Exp _USER_PASSWORD_ = new Exp("User_PassWord");
		public static Exp _USER_EMAIL_ = new Exp("User_Email");
		public static Exp _USER_GENDER_ = new Exp("User_Gender");
		public static Exp _USER_LEVELKEY_ = new Exp("User_LevelKey");
		public static Exp _USER_REGIP_ = new Exp("User_RegIp");
		public static Exp _USER_AVATAR_ = new Exp("User_Avatar");
		public static Exp _USER_REGTIME_ = new Exp("User_RegTime");
		public static Exp _USER_LASTIP_ = new Exp("User_LastIp");
		public static Exp _USER_LASTTIME_ = new Exp("User_LastTime");
		public static Exp _USER_CREDITS_ = new Exp("User_Credits");
		public static Exp _USER_PMSOUND_ = new Exp("User_PMSound");
		public static Exp _USER_INVISIBLE_ = new Exp("User_InVisible");
		public static Exp _USER_NEWPM_ = new Exp("User_NewPM");
		public static Exp _USER_NEWPMCCOUNT_ = new Exp("User_NewPMCcount");
		public static Exp _USER_ONLINESTATE_ = new Exp("User_OnlineState");
		public static Exp _USER_BIRTHDAY_ = new Exp("User_BirthDay");
		public static Exp _USER_SIGN_ = new Exp("User_Sign");
		public static Exp _USER_ADDRESS_ = new Exp("User_Address");
		public static Exp _USER_POSTCODE_ = new Exp("User_PostCode");
		public static Exp _USER_COMPANY_ = new Exp("User_Company");
		public static Exp _USER_JOB_ = new Exp("User_Job");
		public static Exp _USER_CITY_ = new Exp("User_City");
		public static Exp _USER_IM_ = new Exp("User_IM");
		public static Exp _USER_TEL_ = new Exp("User_Tel");
		public static Exp _USER_COUNTRY_ = new Exp("User_Country");
		public static Exp _USER_EXFLAG1_ = new Exp("User_ExFlag1");
		public static Exp _USER_EXFLAG2_ = new Exp("User_ExFlag2");
		public static Exp _USER_EXFLAG3_ = new Exp("User_ExFlag3");
		public static Exp _USER_EXFLAG4_ = new Exp("User_ExFlag4");
		public static Exp _USER_EXFLAG5_ = new Exp("User_ExFlag5");
		public static Exp _USER_EXFLAG6_ = new Exp("User_ExFlag6");
		public static Exp _USER_EXFLAG7_ = new Exp("User_ExFlag7");
		public static Exp _USER_EXFLAG8_ = new Exp("User_ExFlag8");
		public static Exp _USER_EXFLAG9_ = new Exp("User_ExFlag9");
		public static Exp _USER_EXFLAG10_ = new Exp("User_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@User_Id",SqlDbType.Int);
			p.Value = _User_Id;
			rs.Add(p);
			if (_User_Name != null)
			{
				p = new SqlParameter("@User_Name",SqlDbType.NVarChar);
				p.Value = _User_Name;
				rs.Add(p);
			}
			if (_User_RealName != null)
			{
				p = new SqlParameter("@User_RealName",SqlDbType.NVarChar);
				p.Value = _User_RealName;
				rs.Add(p);
			}
			if (_User_PassWord != null)
			{
				p = new SqlParameter("@User_PassWord",SqlDbType.NVarChar);
				p.Value = _User_PassWord;
				rs.Add(p);
			}
			if (_User_Email != null)
			{
				p = new SqlParameter("@User_Email",SqlDbType.NVarChar);
				p.Value = _User_Email;
				rs.Add(p);
			}
			if (_User_Gender != null)
			{
				p = new SqlParameter("@User_Gender",SqlDbType.NVarChar);
				p.Value = _User_Gender;
				rs.Add(p);
			}
			if (_User_LevelKey != null)
			{
				p = new SqlParameter("@User_LevelKey",SqlDbType.NVarChar);
				p.Value = _User_LevelKey;
				rs.Add(p);
			}
			if (_User_RegIp != null)
			{
				p = new SqlParameter("@User_RegIp",SqlDbType.NVarChar);
				p.Value = _User_RegIp;
				rs.Add(p);
			}
			if (_User_Avatar != null)
			{
				p = new SqlParameter("@User_Avatar",SqlDbType.NVarChar);
				p.Value = _User_Avatar;
				rs.Add(p);
			}
			if (_User_RegTime != null)
			{
				if (_User_RegTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@User_RegTime",SqlDbType.DateTime);
					p.Value = _User_RegTime;
					rs.Add(p);
				}
			}
			if (_User_LastIp != null)
			{
				p = new SqlParameter("@User_LastIp",SqlDbType.NVarChar);
				p.Value = _User_LastIp;
				rs.Add(p);
			}
			if (_User_LastTime != null)
			{
				if (_User_LastTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@User_LastTime",SqlDbType.DateTime);
					p.Value = _User_LastTime;
					rs.Add(p);
				}
			}
			p = new SqlParameter("@User_Credits",SqlDbType.Int);
			p.Value = _User_Credits;
			rs.Add(p);
			p = new SqlParameter("@User_PMSound",SqlDbType.Int);
			p.Value = _User_PMSound;
			rs.Add(p);
			p = new SqlParameter("@User_InVisible",SqlDbType.Int);
			p.Value = _User_InVisible;
			rs.Add(p);
			p = new SqlParameter("@User_NewPM",SqlDbType.Int);
			p.Value = _User_NewPM;
			rs.Add(p);
			p = new SqlParameter("@User_NewPMCcount",SqlDbType.Int);
			p.Value = _User_NewPMCcount;
			rs.Add(p);
			p = new SqlParameter("@User_OnlineState",SqlDbType.Int);
			p.Value = _User_OnlineState;
			rs.Add(p);
			if (_User_BirthDay != null)
			{
				if (_User_BirthDay.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@User_BirthDay",SqlDbType.DateTime);
					p.Value = _User_BirthDay;
					rs.Add(p);
				}
			}
			if (_User_Sign != null)
			{
				p = new SqlParameter("@User_Sign",SqlDbType.NVarChar);
				p.Value = _User_Sign;
				rs.Add(p);
			}
			if (_User_Address != null)
			{
				p = new SqlParameter("@User_Address",SqlDbType.NVarChar);
				p.Value = _User_Address;
				rs.Add(p);
			}
			if (_User_PostCode != null)
			{
				p = new SqlParameter("@User_PostCode",SqlDbType.NVarChar);
				p.Value = _User_PostCode;
				rs.Add(p);
			}
			if (_User_Company != null)
			{
				p = new SqlParameter("@User_Company",SqlDbType.NVarChar);
				p.Value = _User_Company;
				rs.Add(p);
			}
			if (_User_Job != null)
			{
				p = new SqlParameter("@User_Job",SqlDbType.NVarChar);
				p.Value = _User_Job;
				rs.Add(p);
			}
			if (_User_City != null)
			{
				p = new SqlParameter("@User_City",SqlDbType.NVarChar);
				p.Value = _User_City;
				rs.Add(p);
			}
			if (_User_IM != null)
			{
				p = new SqlParameter("@User_IM",SqlDbType.NVarChar);
				p.Value = _User_IM;
				rs.Add(p);
			}
			if (_User_Tel != null)
			{
				p = new SqlParameter("@User_Tel",SqlDbType.NVarChar);
				p.Value = _User_Tel;
				rs.Add(p);
			}
			if (_User_Country != null)
			{
				p = new SqlParameter("@User_Country",SqlDbType.NVarChar);
				p.Value = _User_Country;
				rs.Add(p);
			}
			if (_User_ExFlag1 != null)
			{
				p = new SqlParameter("@User_ExFlag1",SqlDbType.NVarChar);
				p.Value = _User_ExFlag1;
				rs.Add(p);
			}
			if (_User_ExFlag2 != null)
			{
				p = new SqlParameter("@User_ExFlag2",SqlDbType.NVarChar);
				p.Value = _User_ExFlag2;
				rs.Add(p);
			}
			if (_User_ExFlag3 != null)
			{
				p = new SqlParameter("@User_ExFlag3",SqlDbType.NVarChar);
				p.Value = _User_ExFlag3;
				rs.Add(p);
			}
			if (_User_ExFlag4 != null)
			{
				p = new SqlParameter("@User_ExFlag4",SqlDbType.NVarChar);
				p.Value = _User_ExFlag4;
				rs.Add(p);
			}
			if (_User_ExFlag5 != null)
			{
				p = new SqlParameter("@User_ExFlag5",SqlDbType.NVarChar);
				p.Value = _User_ExFlag5;
				rs.Add(p);
			}
			if (_User_ExFlag6 != null)
			{
				p = new SqlParameter("@User_ExFlag6",SqlDbType.NVarChar);
				p.Value = _User_ExFlag6;
				rs.Add(p);
			}
			if (_User_ExFlag7 != null)
			{
				p = new SqlParameter("@User_ExFlag7",SqlDbType.NVarChar);
				p.Value = _User_ExFlag7;
				rs.Add(p);
			}
			if (_User_ExFlag8 != null)
			{
				p = new SqlParameter("@User_ExFlag8",SqlDbType.NVarChar);
				p.Value = _User_ExFlag8;
				rs.Add(p);
			}
			if (_User_ExFlag9 != null)
			{
				p = new SqlParameter("@User_ExFlag9",SqlDbType.NVarChar);
				p.Value = _User_ExFlag9;
				rs.Add(p);
			}
			if (_User_ExFlag10 != null)
			{
				p = new SqlParameter("@User_ExFlag10",SqlDbType.NVarChar);
				p.Value = _User_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Id")))
			{
				_User_Id = (System.Int32)Rd["User_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Name")))
			{
				_User_Name = (System.String)Rd["User_Name"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_RealName")))
			{
				_User_RealName = (System.String)Rd["User_RealName"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_PassWord")))
			{
				_User_PassWord = (System.String)Rd["User_PassWord"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Email")))
			{
				_User_Email = (System.String)Rd["User_Email"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Gender")))
			{
				_User_Gender = (System.String)Rd["User_Gender"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_LevelKey")))
			{
				_User_LevelKey = (System.String)Rd["User_LevelKey"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_RegIp")))
			{
				_User_RegIp = (System.String)Rd["User_RegIp"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Avatar")))
			{
				_User_Avatar = (System.String)Rd["User_Avatar"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_RegTime")))
			{
				_User_RegTime = (System.DateTime)Rd["User_RegTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_LastIp")))
			{
				_User_LastIp = (System.String)Rd["User_LastIp"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_LastTime")))
			{
				_User_LastTime = (System.DateTime)Rd["User_LastTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Credits")))
			{
				_User_Credits = (System.Int32)Rd["User_Credits"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_PMSound")))
			{
				_User_PMSound = (System.Int32)Rd["User_PMSound"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_InVisible")))
			{
				_User_InVisible = (System.Int32)Rd["User_InVisible"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_NewPM")))
			{
				_User_NewPM = (System.Int32)Rd["User_NewPM"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_NewPMCcount")))
			{
				_User_NewPMCcount = (System.Int32)Rd["User_NewPMCcount"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_OnlineState")))
			{
				_User_OnlineState = (System.Int32)Rd["User_OnlineState"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_BirthDay")))
			{
				_User_BirthDay = (System.DateTime)Rd["User_BirthDay"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Sign")))
			{
				_User_Sign = (System.String)Rd["User_Sign"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Address")))
			{
				_User_Address = (System.String)Rd["User_Address"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_PostCode")))
			{
				_User_PostCode = (System.String)Rd["User_PostCode"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Company")))
			{
				_User_Company = (System.String)Rd["User_Company"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Job")))
			{
				_User_Job = (System.String)Rd["User_Job"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_City")))
			{
				_User_City = (System.String)Rd["User_City"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_IM")))
			{
				_User_IM = (System.String)Rd["User_IM"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Tel")))
			{
				_User_Tel = (System.String)Rd["User_Tel"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_Country")))
			{
				_User_Country = (System.String)Rd["User_Country"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag1")))
			{
				_User_ExFlag1 = (System.String)Rd["User_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag2")))
			{
				_User_ExFlag2 = (System.String)Rd["User_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag3")))
			{
				_User_ExFlag3 = (System.String)Rd["User_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag4")))
			{
				_User_ExFlag4 = (System.String)Rd["User_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag5")))
			{
				_User_ExFlag5 = (System.String)Rd["User_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag6")))
			{
				_User_ExFlag6 = (System.String)Rd["User_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag7")))
			{
				_User_ExFlag7 = (System.String)Rd["User_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag8")))
			{
				_User_ExFlag8 = (System.String)Rd["User_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag9")))
			{
				_User_ExFlag9 = (System.String)Rd["User_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("User_ExFlag10")))
			{
				_User_ExFlag10 = (System.String)Rd["User_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_User();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_User([User_Name],[User_RealName],[User_PassWord],[User_Email],[User_Gender],[User_LevelKey],[User_RegIp],[User_Avatar],[User_RegTime],[User_LastIp],[User_LastTime],[User_Credits],[User_PMSound],[User_InVisible],[User_NewPM],[User_NewPMCcount],[User_OnlineState],[User_BirthDay],[User_Sign],[User_Address],[User_PostCode],[User_Company],[User_Job],[User_City],[User_IM],[User_Tel],[User_Country],[User_ExFlag1],[User_ExFlag2],[User_ExFlag3],[User_ExFlag4],[User_ExFlag5],[User_ExFlag6],[User_ExFlag7],[User_ExFlag8],[User_ExFlag9],[User_ExFlag10]) VALUES (@User_Name ,@User_RealName ,@User_PassWord ,@User_Email ,@User_Gender ,@User_LevelKey ,@User_RegIp ,@User_Avatar ,@User_RegTime ,@User_LastIp ,@User_LastTime ,@User_Credits ,@User_PMSound ,@User_InVisible ,@User_NewPM ,@User_NewPMCcount ,@User_OnlineState ,@User_BirthDay ,@User_Sign ,@User_Address ,@User_PostCode ,@User_Company ,@User_Job ,@User_City ,@User_IM ,@User_Tel ,@User_Country ,@User_ExFlag1 ,@User_ExFlag2 ,@User_ExFlag3 ,@User_ExFlag4 ,@User_ExFlag5 ,@User_ExFlag6 ,@User_ExFlag7 ,@User_ExFlag8 ,@User_ExFlag9 ,@User_ExFlag10 )";
		}


	}

	public class Dcms_UserLevel:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "UserLevel_Id";
		}
		public string GetObjectTableName()
		{
			return "Dcms_UserLevel";
		}

		private System.Int32 _UserLevel_Id;
		public System.Int32 UserLevel_Id
		{
			get{ return _UserLevel_Id; }
			set{ _UserLevel_Id = value; }
		}
		private System.String _UserLevel_Title;
		public System.String UserLevel_Title
		{
			get{ return _UserLevel_Title; }
			set{ _UserLevel_Title = value; }
		}
		private System.String _UserLevel_Key;
		public System.String UserLevel_Key
		{
			get{ return _UserLevel_Key; }
			set{ _UserLevel_Key = value; }
		}
		private System.Int32 _UserLevel_Stars;
		public System.Int32 UserLevel_Stars
		{
			get{ return _UserLevel_Stars; }
			set{ _UserLevel_Stars = value; }
		}
		private System.String _UserLevel_Color;
		public System.String UserLevel_Color
		{
			get{ return _UserLevel_Color; }
			set{ _UserLevel_Color = value; }
		}
		private System.String _UserLevel_avatar;
		public System.String UserLevel_avatar
		{
			get{ return _UserLevel_avatar; }
			set{ _UserLevel_avatar = value; }
		}
		private System.DateTime _UserLevel_AddTime;
		public System.DateTime UserLevel_AddTime
		{
			get{ return _UserLevel_AddTime; }
			set{ _UserLevel_AddTime = value; }
		}
		private System.String _UserLevel_ExFlag1;
		public System.String UserLevel_ExFlag1
		{
			get{ return _UserLevel_ExFlag1; }
			set{ _UserLevel_ExFlag1 = value; }
		}
		private System.String _UserLevel_ExFlag2;
		public System.String UserLevel_ExFlag2
		{
			get{ return _UserLevel_ExFlag2; }
			set{ _UserLevel_ExFlag2 = value; }
		}
		private System.String _UserLevel_ExFlag3;
		public System.String UserLevel_ExFlag3
		{
			get{ return _UserLevel_ExFlag3; }
			set{ _UserLevel_ExFlag3 = value; }
		}
		private System.String _UserLevel_ExFlag4;
		public System.String UserLevel_ExFlag4
		{
			get{ return _UserLevel_ExFlag4; }
			set{ _UserLevel_ExFlag4 = value; }
		}
		private System.String _UserLevel_ExFlag5;
		public System.String UserLevel_ExFlag5
		{
			get{ return _UserLevel_ExFlag5; }
			set{ _UserLevel_ExFlag5 = value; }
		}
		private System.String _UserLevel_ExFlag6;
		public System.String UserLevel_ExFlag6
		{
			get{ return _UserLevel_ExFlag6; }
			set{ _UserLevel_ExFlag6 = value; }
		}
		private System.String _UserLevel_ExFlag7;
		public System.String UserLevel_ExFlag7
		{
			get{ return _UserLevel_ExFlag7; }
			set{ _UserLevel_ExFlag7 = value; }
		}
		private System.String _UserLevel_ExFlag8;
		public System.String UserLevel_ExFlag8
		{
			get{ return _UserLevel_ExFlag8; }
			set{ _UserLevel_ExFlag8 = value; }
		}
		private System.String _UserLevel_ExFlag9;
		public System.String UserLevel_ExFlag9
		{
			get{ return _UserLevel_ExFlag9; }
			set{ _UserLevel_ExFlag9 = value; }
		}
		private System.String _UserLevel_ExFlag10;
		public System.String UserLevel_ExFlag10
		{
			get{ return _UserLevel_ExFlag10; }
			set{ _UserLevel_ExFlag10 = value; }
		}


		public static Exp _USERLEVEL_ID_ = new Exp("UserLevel_Id");
		public static Exp _USERLEVEL_TITLE_ = new Exp("UserLevel_Title");
		public static Exp _USERLEVEL_KEY_ = new Exp("UserLevel_Key");
		public static Exp _USERLEVEL_STARS_ = new Exp("UserLevel_Stars");
		public static Exp _USERLEVEL_COLOR_ = new Exp("UserLevel_Color");
		public static Exp _USERLEVEL_AVATAR_ = new Exp("UserLevel_avatar");
		public static Exp _USERLEVEL_ADDTIME_ = new Exp("UserLevel_AddTime");
		public static Exp _USERLEVEL_EXFLAG1_ = new Exp("UserLevel_ExFlag1");
		public static Exp _USERLEVEL_EXFLAG2_ = new Exp("UserLevel_ExFlag2");
		public static Exp _USERLEVEL_EXFLAG3_ = new Exp("UserLevel_ExFlag3");
		public static Exp _USERLEVEL_EXFLAG4_ = new Exp("UserLevel_ExFlag4");
		public static Exp _USERLEVEL_EXFLAG5_ = new Exp("UserLevel_ExFlag5");
		public static Exp _USERLEVEL_EXFLAG6_ = new Exp("UserLevel_ExFlag6");
		public static Exp _USERLEVEL_EXFLAG7_ = new Exp("UserLevel_ExFlag7");
		public static Exp _USERLEVEL_EXFLAG8_ = new Exp("UserLevel_ExFlag8");
		public static Exp _USERLEVEL_EXFLAG9_ = new Exp("UserLevel_ExFlag9");
		public static Exp _USERLEVEL_EXFLAG10_ = new Exp("UserLevel_ExFlag10");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@UserLevel_Id",SqlDbType.Int);
			p.Value = _UserLevel_Id;
			rs.Add(p);
			if (_UserLevel_Title != null)
			{
				p = new SqlParameter("@UserLevel_Title",SqlDbType.VarChar);
				p.Value = _UserLevel_Title;
				rs.Add(p);
			}
			if (_UserLevel_Key != null)
			{
				p = new SqlParameter("@UserLevel_Key",SqlDbType.VarChar);
				p.Value = _UserLevel_Key;
				rs.Add(p);
			}
			p = new SqlParameter("@UserLevel_Stars",SqlDbType.Int);
			p.Value = _UserLevel_Stars;
			rs.Add(p);
			if (_UserLevel_Color != null)
			{
				p = new SqlParameter("@UserLevel_Color",SqlDbType.Char);
				p.Value = _UserLevel_Color;
				rs.Add(p);
			}
			if (_UserLevel_avatar != null)
			{
				p = new SqlParameter("@UserLevel_avatar",SqlDbType.VarChar);
				p.Value = _UserLevel_avatar;
				rs.Add(p);
			}
			if (_UserLevel_AddTime != null)
			{
				if (_UserLevel_AddTime.Ticks > DateTime.MinValue.AddYears(1800).Ticks)
				{
					p = new SqlParameter("@UserLevel_AddTime",SqlDbType.DateTime);
					p.Value = _UserLevel_AddTime;
					rs.Add(p);
				}
			}
			if (_UserLevel_ExFlag1 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag1",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag1;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag2 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag2",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag2;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag3 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag3",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag3;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag4 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag4",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag4;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag5 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag5",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag5;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag6 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag6",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag6;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag7 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag7",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag7;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag8 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag8",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag8;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag9 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag9",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag9;
				rs.Add(p);
			}
			if (_UserLevel_ExFlag10 != null)
			{
				p = new SqlParameter("@UserLevel_ExFlag10",SqlDbType.NVarChar);
				p.Value = _UserLevel_ExFlag10;
				rs.Add(p);
			}
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_Id")))
			{
				_UserLevel_Id = (System.Int32)Rd["UserLevel_Id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_Title")))
			{
				_UserLevel_Title = (System.String)Rd["UserLevel_Title"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_Key")))
			{
				_UserLevel_Key = (System.String)Rd["UserLevel_Key"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_Stars")))
			{
				_UserLevel_Stars = (System.Int32)Rd["UserLevel_Stars"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_Color")))
			{
				_UserLevel_Color = (System.String)Rd["UserLevel_Color"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_avatar")))
			{
				_UserLevel_avatar = (System.String)Rd["UserLevel_avatar"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_AddTime")))
			{
				_UserLevel_AddTime = (System.DateTime)Rd["UserLevel_AddTime"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag1")))
			{
				_UserLevel_ExFlag1 = (System.String)Rd["UserLevel_ExFlag1"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag2")))
			{
				_UserLevel_ExFlag2 = (System.String)Rd["UserLevel_ExFlag2"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag3")))
			{
				_UserLevel_ExFlag3 = (System.String)Rd["UserLevel_ExFlag3"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag4")))
			{
				_UserLevel_ExFlag4 = (System.String)Rd["UserLevel_ExFlag4"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag5")))
			{
				_UserLevel_ExFlag5 = (System.String)Rd["UserLevel_ExFlag5"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag6")))
			{
				_UserLevel_ExFlag6 = (System.String)Rd["UserLevel_ExFlag6"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag7")))
			{
				_UserLevel_ExFlag7 = (System.String)Rd["UserLevel_ExFlag7"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag8")))
			{
				_UserLevel_ExFlag8 = (System.String)Rd["UserLevel_ExFlag8"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag9")))
			{
				_UserLevel_ExFlag9 = (System.String)Rd["UserLevel_ExFlag9"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("UserLevel_ExFlag10")))
			{
				_UserLevel_ExFlag10 = (System.String)Rd["UserLevel_ExFlag10"];
			}
		}


		public Object CreateNewInstance()
		{
			return new Dcms_UserLevel();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO Dcms_UserLevel([UserLevel_Title],[UserLevel_Key],[UserLevel_Stars],[UserLevel_Color],[UserLevel_avatar],[UserLevel_AddTime],[UserLevel_ExFlag1],[UserLevel_ExFlag2],[UserLevel_ExFlag3],[UserLevel_ExFlag4],[UserLevel_ExFlag5],[UserLevel_ExFlag6],[UserLevel_ExFlag7],[UserLevel_ExFlag8],[UserLevel_ExFlag9],[UserLevel_ExFlag10]) VALUES (@UserLevel_Title ,@UserLevel_Key ,@UserLevel_Stars ,@UserLevel_Color ,@UserLevel_avatar ,@UserLevel_AddTime ,@UserLevel_ExFlag1 ,@UserLevel_ExFlag2 ,@UserLevel_ExFlag3 ,@UserLevel_ExFlag4 ,@UserLevel_ExFlag5 ,@UserLevel_ExFlag6 ,@UserLevel_ExFlag7 ,@UserLevel_ExFlag8 ,@UserLevel_ExFlag9 ,@UserLevel_ExFlag10 )";
		}


	}

	public class dtproperties:Dcms.Orm.ActiveBase,Dcms.Orm.IQueryable
	{
		public string GetPrimaryKeyName()
		{
			return "id";
		}
		public string GetObjectTableName()
		{
			return "dtproperties";
		}

		private System.Int32 _id;
		public System.Int32 id
		{
			get{ return _id; }
			set{ _id = value; }
		}
		private System.Int32 _objectid;
		public System.Int32 objectid
		{
			get{ return _objectid; }
			set{ _objectid = value; }
		}
		private System.String _property;
		public System.String property
		{
			get{ return _property; }
			set{ _property = value; }
		}
		private System.String _value;
		public System.String value
		{
			get{ return _value; }
			set{ _value = value; }
		}
		private System.String _uvalue;
		public System.String uvalue
		{
			get{ return _uvalue; }
			set{ _uvalue = value; }
		}
		private System.Byte[] _lvalue;
		public System.Byte[] lvalue
		{
			get{ return _lvalue; }
			set{ _lvalue = value; }
		}
		private System.Int32 _version;
		public System.Int32 version
		{
			get{ return _version; }
			set{ _version = value; }
		}


		public static Exp _ID_ = new Exp("id");
		public static Exp _OBJECTID_ = new Exp("objectid");
		public static Exp _PROPERTY_ = new Exp("property");
		public static Exp _VALUE_ = new Exp("value");
		public static Exp _UVALUE_ = new Exp("uvalue");
		public static Exp _LVALUE_ = new Exp("lvalue");
		public static Exp _VERSION_ = new Exp("version");


		public List<IDbDataParameter> PreparePrameter()
		{
			IDbDataParameter p = null;
			List<IDbDataParameter> rs = new List<IDbDataParameter>();
			p = new SqlParameter("@id",SqlDbType.Int);
			p.Value = _id;
			rs.Add(p);
			p = new SqlParameter("@objectid",SqlDbType.Int);
			p.Value = _objectid;
			rs.Add(p);
			if (_property != null)
			{
				p = new SqlParameter("@property",SqlDbType.VarChar);
				p.Value = _property;
				rs.Add(p);
			}
			if (_value != null)
			{
				p = new SqlParameter("@value",SqlDbType.VarChar);
				p.Value = _value;
				rs.Add(p);
			}
			if (_uvalue != null)
			{
				p = new SqlParameter("@uvalue",SqlDbType.NVarChar);
				p.Value = _uvalue;
				rs.Add(p);
			}
			if (_lvalue != null)
			{
				p = new SqlParameter("@lvalue",SqlDbType.Image);
				p.Value = _lvalue;
				rs.Add(p);
			}
			p = new SqlParameter("@version",SqlDbType.Int);
			p.Value = _version;
			rs.Add(p);
			return rs;
		}


		public void LoadFromReader(IDataReader Rd)
		{
			if(!Rd.IsDBNull(Rd.GetOrdinal("id")))
			{
				_id = (System.Int32)Rd["id"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("objectid")))
			{
				_objectid = (System.Int32)Rd["objectid"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("property")))
			{
				_property = (System.String)Rd["property"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("value")))
			{
				_value = (System.String)Rd["value"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("uvalue")))
			{
				_uvalue = (System.String)Rd["uvalue"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("lvalue")))
			{
				_lvalue = (System.Byte[])Rd["lvalue"];
			}
			if(!Rd.IsDBNull(Rd.GetOrdinal("version")))
			{
				_version = (System.Int32)Rd["version"];
			}
		}


		public Object CreateNewInstance()
		{
			return new dtproperties();
		}

		public string GetInsertSql()
		{
			return "INSERT INTO dtproperties([objectid],[property],[value],[uvalue],[lvalue],[version]) VALUES (@objectid ,@property ,@value ,@uvalue ,@lvalue ,@version )";
		}


	}


}
public class DateSettings
{
	public const string SqlDb = "SqlDb";
}
