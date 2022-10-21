/*
				   File: type_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem
			Description: K2BMultiLevelMenu
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
	[XmlRoot(ElementName="K2BMultiLevelMenuItem")]
	[XmlType(TypeName="K2BMultiLevelMenuItem" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem : GxUserType
	{
		public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Code = "";

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Title = "";

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageurl = "";

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageclass = "";

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Link = "";

		}

		public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem(IGxContext context)
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
			AddObjectProperty("Code", gxTpr_Code, false);


			AddObjectProperty("Title", gxTpr_Title, false);


			AddObjectProperty("ImageUrl", gxTpr_Imageurl, false);


			AddObjectProperty("ImageClass", gxTpr_Imageclass, false);


			AddObjectProperty("Link", gxTpr_Link, false);

			if (gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items != null)
			{
				AddObjectProperty("Items", gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items, false);  
			}

			AddObjectProperty("ShowInExtraSmall", gxTpr_Showinextrasmall, false);


			AddObjectProperty("ShowInSmall", gxTpr_Showinsmall, false);


			AddObjectProperty("ShowInMedium", gxTpr_Showinmedium, false);


			AddObjectProperty("ShowInLarge", gxTpr_Showinlarge, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Code")]
		[XmlElement(ElementName="Code")]
		public String gxTpr_Code
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Code; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Code = value;
				SetDirty("Code");
			}
		}




		[SoapElement(ElementName="Title")]
		[XmlElement(ElementName="Title")]
		public String gxTpr_Title
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Title; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Title = value;
				SetDirty("Title");
			}
		}




		[SoapElement(ElementName="ImageUrl")]
		[XmlElement(ElementName="ImageUrl")]
		public String gxTpr_Imageurl
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageurl; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageurl = value;
				SetDirty("Imageurl");
			}
		}




		[SoapElement(ElementName="ImageClass")]
		[XmlElement(ElementName="ImageClass")]
		public String gxTpr_Imageclass
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageclass; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageclass = value;
				SetDirty("Imageclass");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public String gxTpr_Link
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Link; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Link = value;
				SetDirty("Link");
			}
		}




		[SoapElement(ElementName="Items" )]
		[XmlArray(ElementName="Items"  )]
		[XmlArrayItemAttribute(ElementName="K2BMultiLevelMenuItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTpr_Items_GXBaseCollection
		{
			get {
				if ( gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items == null )
				{
					gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenu", "");
				}
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items;
			}
			set {
				if ( gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items == null )
				{
					gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenu", "");
				}
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N = 0;

				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = value;
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTpr_Items
		{
			get {
				if ( gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items == null )
				{
					gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = new GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>( context, "K2BMultiLevelMenu", "");
				}
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N = 0;

				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items ;
			}
			set {
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N = 0;

				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = value;
				SetDirty("Items");
			}
		}

		public void gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_SetNull()
		{
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N = 1;

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = null;
			return  ;
		}

		public bool gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_IsNull()
		{
			if (gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items == null)
			{
				return true ;
			}
			return false ;
		}

		public bool ShouldSerializegxTpr_Items_GXBaseCollection_Json()
		{
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items != null && gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items.Count > 0;

		}


		[SoapElement(ElementName="ShowInExtraSmall")]
		[XmlElement(ElementName="ShowInExtraSmall")]
		public bool gxTpr_Showinextrasmall
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinextrasmall; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinextrasmall = value;
				SetDirty("Showinextrasmall");
			}
		}




		[SoapElement(ElementName="ShowInSmall")]
		[XmlElement(ElementName="ShowInSmall")]
		public bool gxTpr_Showinsmall
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinsmall; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinsmall = value;
				SetDirty("Showinsmall");
			}
		}




		[SoapElement(ElementName="ShowInMedium")]
		[XmlElement(ElementName="ShowInMedium")]
		public bool gxTpr_Showinmedium
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinmedium; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinmedium = value;
				SetDirty("Showinmedium");
			}
		}




		[SoapElement(ElementName="ShowInLarge")]
		[XmlElement(ElementName="ShowInLarge")]
		public bool gxTpr_Showinlarge
		{
			get { 
				return gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinlarge; 
			}
			set { 
				gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinlarge = value;
				SetDirty("Showinlarge");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Code = "";
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Title = "";
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageurl = "";
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageclass = "";
			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Link = "";

			gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N = 1;





			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Code;
		 

		protected String gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Title;
		 

		protected String gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageurl;
		 

		protected String gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Imageclass;
		 

		protected String gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Link;
		 
		protected short gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items_N;
		protected GXBaseCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem> gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Items = null;  

		protected bool gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinextrasmall;
		 

		protected bool gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinsmall;
		 

		protected bool gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinmedium;
		 

		protected bool gxTv_SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_Showinlarge;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"K2BMultiLevelMenuItem", Namespace="TABLEROS_WEB")]
	public class SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface : GxGenericCollectionItem<SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface( ) : base()
		{
		}

		public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface( SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Code", Order=0)]
		public  String gxTpr_Code
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Code);

			}
			set { 
				 sdt.gxTpr_Code = value;
			}
		}

		[DataMember(Name="Title", Order=1)]
		public  String gxTpr_Title
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Title);

			}
			set { 
				 sdt.gxTpr_Title = value;
			}
		}

		[DataMember(Name="ImageUrl", Order=2)]
		public  String gxTpr_Imageurl
		{
			get { 
				return sdt.gxTpr_Imageurl;

			}
			set { 
				 sdt.gxTpr_Imageurl = value;
			}
		}

		[DataMember(Name="ImageClass", Order=3)]
		public  String gxTpr_Imageclass
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Imageclass);

			}
			set { 
				 sdt.gxTpr_Imageclass = value;
			}
		}

		[DataMember(Name="Link", Order=4)]
		public  String gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}

		[DataMember(Name="Items", Order=5, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface> gxTpr_Items
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Items_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem_RESTInterface>(sdt.gxTpr_Items);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Items);
			}
		}

		[DataMember(Name="ShowInExtraSmall", Order=6)]
		public bool gxTpr_Showinextrasmall
		{
			get { 
				return sdt.gxTpr_Showinextrasmall;

			}
			set { 
				sdt.gxTpr_Showinextrasmall = value;
			}
		}

		[DataMember(Name="ShowInSmall", Order=7)]
		public bool gxTpr_Showinsmall
		{
			get { 
				return sdt.gxTpr_Showinsmall;

			}
			set { 
				sdt.gxTpr_Showinsmall = value;
			}
		}

		[DataMember(Name="ShowInMedium", Order=8)]
		public bool gxTpr_Showinmedium
		{
			get { 
				return sdt.gxTpr_Showinmedium;

			}
			set { 
				sdt.gxTpr_Showinmedium = value;
			}
		}

		[DataMember(Name="ShowInLarge", Order=9)]
		public bool gxTpr_Showinlarge
		{
			get { 
				return sdt.gxTpr_Showinlarge;

			}
			set { 
				sdt.gxTpr_Showinlarge = value;
			}
		}


		#endregion

		public SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem sdt
		{
			get { 
				return (SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem)Sdt;
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
				sdt = new SdtK2BMultiLevelMenu_K2BMultiLevelMenuItem() ;
			}
		}
	}
	#endregion
}