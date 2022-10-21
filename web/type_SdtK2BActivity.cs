/*
				   File: type_SdtK2BActivity
			Description: K2BActivity
				 Author: Nemo 🐠 for C# version 16.0.10.142546
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web.Services.Protocols;


namespace GeneXus.Programs
{
	[XmlSerializerFormat]
	[XmlRoot(ElementName="K2BActivity")]
	[XmlType(TypeName="K2BActivity" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BActivity : GxUserType
	{
		public SdtK2BActivity( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BActivity_Entityname = "";

			gxTv_SdtK2BActivity_Transactionname = "";

			gxTv_SdtK2BActivity_Pgmname = "";

			gxTv_SdtK2BActivity_Standardactivitytype = "";

			gxTv_SdtK2BActivity_Useractivitytype = "";

			gxTv_SdtK2BActivity_Description = "";

		}

		public SdtK2BActivity(IGxContext context)
		{
			this.context = context;
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override String JsonMap(String value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (String)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			AddObjectProperty("EntityName", gxTpr_Entityname, false);


			AddObjectProperty("TransactionName", gxTpr_Transactionname, false);


			AddObjectProperty("PgmName", gxTpr_Pgmname, false);


			AddObjectProperty("StandardActivityType", gxTpr_Standardactivitytype, false);


			AddObjectProperty("UserActivityType", gxTpr_Useractivitytype, false);


			AddObjectProperty("Description", gxTpr_Description, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="EntityName")]
		[XmlElement(ElementName="EntityName")]
		public String gxTpr_Entityname
		{
			get { 
				return gxTv_SdtK2BActivity_Entityname; 
			}
			set { 
				gxTv_SdtK2BActivity_Entityname = value;
				SetDirty("Entityname");
			}
		}




		[SoapElement(ElementName="TransactionName")]
		[XmlElement(ElementName="TransactionName")]
		public String gxTpr_Transactionname
		{
			get { 
				return gxTv_SdtK2BActivity_Transactionname; 
			}
			set { 
				gxTv_SdtK2BActivity_Transactionname = value;
				SetDirty("Transactionname");
			}
		}




		[SoapElement(ElementName="PgmName")]
		[XmlElement(ElementName="PgmName")]
		public String gxTpr_Pgmname
		{
			get { 
				return gxTv_SdtK2BActivity_Pgmname; 
			}
			set { 
				gxTv_SdtK2BActivity_Pgmname = value;
				SetDirty("Pgmname");
			}
		}




		[SoapElement(ElementName="StandardActivityType")]
		[XmlElement(ElementName="StandardActivityType")]
		public String gxTpr_Standardactivitytype
		{
			get { 
				return gxTv_SdtK2BActivity_Standardactivitytype; 
			}
			set { 
				gxTv_SdtK2BActivity_Standardactivitytype = value;
				SetDirty("Standardactivitytype");
			}
		}




		[SoapElement(ElementName="UserActivityType")]
		[XmlElement(ElementName="UserActivityType")]
		public String gxTpr_Useractivitytype
		{
			get { 
				return gxTv_SdtK2BActivity_Useractivitytype; 
			}
			set { 
				gxTv_SdtK2BActivity_Useractivitytype = value;
				SetDirty("Useractivitytype");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public String gxTpr_Description
		{
			get { 
				return gxTv_SdtK2BActivity_Description; 
			}
			set { 
				gxTv_SdtK2BActivity_Description = value;
				SetDirty("Description");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BActivity_Entityname = "";
			gxTv_SdtK2BActivity_Transactionname = "";
			gxTv_SdtK2BActivity_Pgmname = "";
			gxTv_SdtK2BActivity_Standardactivitytype = "";
			gxTv_SdtK2BActivity_Useractivitytype = "";
			gxTv_SdtK2BActivity_Description = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BActivity_Entityname;
		 

		protected String gxTv_SdtK2BActivity_Transactionname;
		 

		protected String gxTv_SdtK2BActivity_Pgmname;
		 

		protected String gxTv_SdtK2BActivity_Standardactivitytype;
		 

		protected String gxTv_SdtK2BActivity_Useractivitytype;
		 

		protected String gxTv_SdtK2BActivity_Description;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BActivity", Namespace="TABLEROS_WEB")]
	public class SdtK2BActivity_RESTInterface : GxGenericCollectionItem<SdtK2BActivity>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BActivity_RESTInterface( ) : base()
		{
		}

		public SdtK2BActivity_RESTInterface( SdtK2BActivity psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="EntityName", Order=0)]
		public  String gxTpr_Entityname
		{
			get { 
				return sdt.gxTpr_Entityname;

			}
			set { 
				 sdt.gxTpr_Entityname = value;
			}
		}

		[DataMember(Name="TransactionName", Order=1)]
		public  String gxTpr_Transactionname
		{
			get { 
				return sdt.gxTpr_Transactionname;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="PgmName", Order=2)]
		public  String gxTpr_Pgmname
		{
			get { 
				return sdt.gxTpr_Pgmname;

			}
			set { 
				 sdt.gxTpr_Pgmname = value;
			}
		}

		[DataMember(Name="StandardActivityType", Order=3)]
		public  String gxTpr_Standardactivitytype
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Standardactivitytype);

			}
			set { 
				 sdt.gxTpr_Standardactivitytype = value;
			}
		}

		[DataMember(Name="UserActivityType", Order=4)]
		public  String gxTpr_Useractivitytype
		{
			get { 
				return sdt.gxTpr_Useractivitytype;

			}
			set { 
				 sdt.gxTpr_Useractivitytype = value;
			}
		}

		[DataMember(Name="Description", Order=5)]
		public  String gxTpr_Description
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Description);

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}


		#endregion

		public SdtK2BActivity sdt
		{
			get { 
				return (SdtK2BActivity)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtK2BActivity() ;
			}
		}
	}
	#endregion
}