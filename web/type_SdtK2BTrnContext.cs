/*
				   File: type_SdtK2BTrnContext
			Description: K2BTrnContext
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
	[XmlRoot(ElementName="K2BTrnContext")]
	[XmlType(TypeName="K2BTrnContext" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BTrnContext : GxUserType
	{
		public SdtK2BTrnContext( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BTrnContext_Transactionname = "";

			gxTv_SdtK2BTrnContext_Callerurl = "";

			gxTv_SdtK2BTrnContext_Entitymanagername = "";

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = "";

			gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = "";

			gxTv_SdtK2BTrnContext_Returnmode = "";

		}

		public SdtK2BTrnContext(IGxContext context)
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
			AddObjectProperty("TransactionName", gxTpr_Transactionname, false);


			AddObjectProperty("CallerUrl", gxTpr_Callerurl, false);


			AddObjectProperty("EntityManagerName", gxTpr_Entitymanagername, false);


			AddObjectProperty("EntityManagerNextTaskCode", gxTpr_Entitymanagernexttaskcode, false);


			AddObjectProperty("EntityManagerNextTaskMode", gxTpr_Entitymanagernexttaskmode, false);


			AddObjectProperty("ReturnMode", gxTpr_Returnmode, false);


			AddObjectProperty("SavePK", gxTpr_Savepk, false);

			if (gxTv_SdtK2BTrnContext_Afterinsert != null)
			{
				AddObjectProperty("AfterInsert", gxTv_SdtK2BTrnContext_Afterinsert, false);  
			}
			if (gxTv_SdtK2BTrnContext_Afterupdate != null)
			{
				AddObjectProperty("AfterUpdate", gxTv_SdtK2BTrnContext_Afterupdate, false);  
			}
			if (gxTv_SdtK2BTrnContext_Afterdelete != null)
			{
				AddObjectProperty("AfterDelete", gxTv_SdtK2BTrnContext_Afterdelete, false);  
			}
			if (gxTv_SdtK2BTrnContext_Attributes != null)
			{
				AddObjectProperty("Attributes", gxTv_SdtK2BTrnContext_Attributes, false);  
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TransactionName")]
		[XmlElement(ElementName="TransactionName")]
		public String gxTpr_Transactionname
		{
			get { 
				return gxTv_SdtK2BTrnContext_Transactionname; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Transactionname = value;
				SetDirty("Transactionname");
			}
		}




		[SoapElement(ElementName="CallerUrl")]
		[XmlElement(ElementName="CallerUrl")]
		public String gxTpr_Callerurl
		{
			get { 
				return gxTv_SdtK2BTrnContext_Callerurl; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Callerurl = value;
				SetDirty("Callerurl");
			}
		}




		[SoapElement(ElementName="EntityManagerName")]
		[XmlElement(ElementName="EntityManagerName")]
		public String gxTpr_Entitymanagername
		{
			get { 
				return gxTv_SdtK2BTrnContext_Entitymanagername; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Entitymanagername = value;
				SetDirty("Entitymanagername");
			}
		}




		[SoapElement(ElementName="EntityManagerNextTaskCode")]
		[XmlElement(ElementName="EntityManagerNextTaskCode")]
		public String gxTpr_Entitymanagernexttaskcode
		{
			get { 
				return gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = value;
				SetDirty("Entitymanagernexttaskcode");
			}
		}




		[SoapElement(ElementName="EntityManagerNextTaskMode")]
		[XmlElement(ElementName="EntityManagerNextTaskMode")]
		public String gxTpr_Entitymanagernexttaskmode
		{
			get { 
				return gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = value;
				SetDirty("Entitymanagernexttaskmode");
			}
		}




		[SoapElement(ElementName="ReturnMode")]
		[XmlElement(ElementName="ReturnMode")]
		public String gxTpr_Returnmode
		{
			get { 
				return gxTv_SdtK2BTrnContext_Returnmode; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Returnmode = value;
				SetDirty("Returnmode");
			}
		}




		[SoapElement(ElementName="SavePK")]
		[XmlElement(ElementName="SavePK")]
		public bool gxTpr_Savepk
		{
			get { 
				return gxTv_SdtK2BTrnContext_Savepk; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Savepk = value;
				SetDirty("Savepk");
			}
		}



		[SoapElement(ElementName="AfterInsert")]
		[XmlElement(ElementName="AfterInsert")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterinsert
		{
			get { 
				if ( gxTv_SdtK2BTrnContext_Afterinsert == null )
				{
					gxTv_SdtK2BTrnContext_Afterinsert = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterinsert; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Afterinsert = value;
				SetDirty("Afterinsert");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterinsert_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterinsert_N = 1;

			gxTv_SdtK2BTrnContext_Afterinsert = null;
			return  ;
		}

		public bool gxTv_SdtK2BTrnContext_Afterinsert_IsNull()
		{
			if (gxTv_SdtK2BTrnContext_Afterinsert == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Afterinsert_Json()
		{
				return gxTv_SdtK2BTrnContext_Afterinsert != null;

		}

		[SoapElement(ElementName="AfterUpdate")]
		[XmlElement(ElementName="AfterUpdate")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterupdate
		{
			get { 
				if ( gxTv_SdtK2BTrnContext_Afterupdate == null )
				{
					gxTv_SdtK2BTrnContext_Afterupdate = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterupdate; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Afterupdate = value;
				SetDirty("Afterupdate");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterupdate_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterupdate_N = 1;

			gxTv_SdtK2BTrnContext_Afterupdate = null;
			return  ;
		}

		public bool gxTv_SdtK2BTrnContext_Afterupdate_IsNull()
		{
			if (gxTv_SdtK2BTrnContext_Afterupdate == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Afterupdate_Json()
		{
				return gxTv_SdtK2BTrnContext_Afterupdate != null;

		}

		[SoapElement(ElementName="AfterDelete")]
		[XmlElement(ElementName="AfterDelete")]
		public GeneXus.Programs.SdtK2BTrnNavigation gxTpr_Afterdelete
		{
			get { 
				if ( gxTv_SdtK2BTrnContext_Afterdelete == null )
				{
					gxTv_SdtK2BTrnContext_Afterdelete = new GeneXus.Programs.SdtK2BTrnNavigation(context);
				}
				return gxTv_SdtK2BTrnContext_Afterdelete; 
			}
			set { 
				gxTv_SdtK2BTrnContext_Afterdelete = value;
				SetDirty("Afterdelete");
			}
		}
		public void gxTv_SdtK2BTrnContext_Afterdelete_SetNull()
		{
			gxTv_SdtK2BTrnContext_Afterdelete_N = 1;

			gxTv_SdtK2BTrnContext_Afterdelete = null;
			return  ;
		}

		public bool gxTv_SdtK2BTrnContext_Afterdelete_IsNull()
		{
			if (gxTv_SdtK2BTrnContext_Afterdelete == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Afterdelete_Json()
		{
				return gxTv_SdtK2BTrnContext_Afterdelete != null;

		}


		[SoapElement(ElementName="Attributes" )]
		[XmlArray(ElementName="Attributes"  )]
		[XmlArrayItemAttribute(ElementName="Attribute" , IsNullable=false )]
		public GXBaseCollection<SdtK2BTrnContext_Attribute> gxTpr_Attributes
		{
			get {
				if ( gxTv_SdtK2BTrnContext_Attributes == null )
				{
					gxTv_SdtK2BTrnContext_Attributes = new GXBaseCollection<SdtK2BTrnContext_Attribute>( context, "K2BTrnContext.Attribute", "");
				}
				return gxTv_SdtK2BTrnContext_Attributes;
			}
			set {
				if ( gxTv_SdtK2BTrnContext_Attributes == null )
				{
					gxTv_SdtK2BTrnContext_Attributes = new GXBaseCollection<SdtK2BTrnContext_Attribute>( context, "K2BTrnContext.Attribute", "");
				}
				gxTv_SdtK2BTrnContext_Attributes_N = 0;

				gxTv_SdtK2BTrnContext_Attributes = value;
				SetDirty("Attributes");
			}
		}

		public void gxTv_SdtK2BTrnContext_Attributes_SetNull()
		{
			gxTv_SdtK2BTrnContext_Attributes_N = 1;

			gxTv_SdtK2BTrnContext_Attributes = null;
			return  ;
		}

		public bool gxTv_SdtK2BTrnContext_Attributes_IsNull()
		{
			if (gxTv_SdtK2BTrnContext_Attributes == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json()
		{
				return gxTv_SdtK2BTrnContext_Attributes != null && gxTv_SdtK2BTrnContext_Attributes.Count > 0;

		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BTrnContext_Transactionname = "";
			gxTv_SdtK2BTrnContext_Callerurl = "";
			gxTv_SdtK2BTrnContext_Entitymanagername = "";
			gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode = "";
			gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode = "";
			gxTv_SdtK2BTrnContext_Returnmode = "";


			gxTv_SdtK2BTrnContext_Afterinsert_N = 1;


			gxTv_SdtK2BTrnContext_Afterupdate_N = 1;


			gxTv_SdtK2BTrnContext_Afterdelete_N = 1;


			gxTv_SdtK2BTrnContext_Attributes_N = 1;

			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BTrnContext_Transactionname;
		 

		protected String gxTv_SdtK2BTrnContext_Callerurl;
		 

		protected String gxTv_SdtK2BTrnContext_Entitymanagername;
		 

		protected String gxTv_SdtK2BTrnContext_Entitymanagernexttaskcode;
		 

		protected String gxTv_SdtK2BTrnContext_Entitymanagernexttaskmode;
		 

		protected String gxTv_SdtK2BTrnContext_Returnmode;
		 

		protected bool gxTv_SdtK2BTrnContext_Savepk;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterinsert = null;
		protected short gxTv_SdtK2BTrnContext_Afterinsert_N;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterupdate = null;
		protected short gxTv_SdtK2BTrnContext_Afterupdate_N;
		 

		protected GeneXus.Programs.SdtK2BTrnNavigation gxTv_SdtK2BTrnContext_Afterdelete = null;
		protected short gxTv_SdtK2BTrnContext_Afterdelete_N;
		 
		protected short gxTv_SdtK2BTrnContext_Attributes_N;
		protected GXBaseCollection<SdtK2BTrnContext_Attribute> gxTv_SdtK2BTrnContext_Attributes = null; 



		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BTrnContext", Namespace="TABLEROS_WEB")]
	public class SdtK2BTrnContext_RESTInterface : GxGenericCollectionItem<SdtK2BTrnContext>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BTrnContext_RESTInterface( ) : base()
		{
		}

		public SdtK2BTrnContext_RESTInterface( SdtK2BTrnContext psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TransactionName", Order=0)]
		public  String gxTpr_Transactionname
		{
			get { 
				return sdt.gxTpr_Transactionname;

			}
			set { 
				 sdt.gxTpr_Transactionname = value;
			}
		}

		[DataMember(Name="CallerUrl", Order=1)]
		public  String gxTpr_Callerurl
		{
			get { 
				return sdt.gxTpr_Callerurl;

			}
			set { 
				 sdt.gxTpr_Callerurl = value;
			}
		}

		[DataMember(Name="EntityManagerName", Order=2)]
		public  String gxTpr_Entitymanagername
		{
			get { 
				return sdt.gxTpr_Entitymanagername;

			}
			set { 
				 sdt.gxTpr_Entitymanagername = value;
			}
		}

		[DataMember(Name="EntityManagerNextTaskCode", Order=3)]
		public  String gxTpr_Entitymanagernexttaskcode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Entitymanagernexttaskcode);

			}
			set { 
				 sdt.gxTpr_Entitymanagernexttaskcode = value;
			}
		}

		[DataMember(Name="EntityManagerNextTaskMode", Order=4)]
		public  String gxTpr_Entitymanagernexttaskmode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Entitymanagernexttaskmode);

			}
			set { 
				 sdt.gxTpr_Entitymanagernexttaskmode = value;
			}
		}

		[DataMember(Name="ReturnMode", Order=5)]
		public  String gxTpr_Returnmode
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Returnmode);

			}
			set { 
				 sdt.gxTpr_Returnmode = value;
			}
		}

		[DataMember(Name="SavePK", Order=6)]
		public bool gxTpr_Savepk
		{
			get { 
				return sdt.gxTpr_Savepk;

			}
			set { 
				sdt.gxTpr_Savepk = value;
			}
		}

		[DataMember(Name="AfterInsert", Order=7, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterinsert
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterinsert_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterinsert);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterinsert = value.sdt;
			}
		}

		[DataMember(Name="AfterUpdate", Order=8, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterupdate
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterupdate_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterupdate);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterupdate = value.sdt;
			}
		}

		[DataMember(Name="AfterDelete", Order=9, EmitDefaultValue=false)]
		public GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface gxTpr_Afterdelete
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Afterdelete_Json())
					return new GeneXus.Programs.SdtK2BTrnNavigation_RESTInterface(sdt.gxTpr_Afterdelete);
				else
					return null;

			}
			set { 
				sdt.gxTpr_Afterdelete = value.sdt;
			}
		}

		[DataMember(Name="Attributes", Order=10, EmitDefaultValue=false)]
		public GxGenericCollection<SdtK2BTrnContext_Attribute_RESTInterface> gxTpr_Attributes
		{
			get {
				if (sdt.ShouldSerializegxTpr_Attributes_GxSimpleCollection_Json())
					return new GxGenericCollection<SdtK2BTrnContext_Attribute_RESTInterface>(sdt.gxTpr_Attributes);
				else
					return null;

			}
			set {
				value.LoadCollection(sdt.gxTpr_Attributes);
			}
		}


		#endregion

		public SdtK2BTrnContext sdt
		{
			get { 
				return (SdtK2BTrnContext)Sdt;
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
				sdt = new SdtK2BTrnContext() ;
			}
		}
	}
	#endregion
}