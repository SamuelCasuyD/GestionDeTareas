/*
				   File: type_SdtK2BProgramNames_ProgramName
			Description: K2BProgramNames
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
	[XmlRoot(ElementName="ProgramName")]
	[XmlType(TypeName="ProgramName" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtK2BProgramNames_ProgramName : GxUserType
	{
		public SdtK2BProgramNames_ProgramName( )
		{
			/* Constructor for serialization */
			gxTv_SdtK2BProgramNames_ProgramName_Name = "";

			gxTv_SdtK2BProgramNames_ProgramName_Description = "";

			gxTv_SdtK2BProgramNames_ProgramName_Link = "";

		}

		public SdtK2BProgramNames_ProgramName(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);


			AddObjectProperty("Description", gxTpr_Description, false);


			AddObjectProperty("Link", gxTpr_Link, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public String gxTpr_Name
		{
			get { 
				return gxTv_SdtK2BProgramNames_ProgramName_Name; 
			}
			set { 
				gxTv_SdtK2BProgramNames_ProgramName_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Description")]
		[XmlElement(ElementName="Description")]
		public String gxTpr_Description
		{
			get { 
				return gxTv_SdtK2BProgramNames_ProgramName_Description; 
			}
			set { 
				gxTv_SdtK2BProgramNames_ProgramName_Description = value;
				SetDirty("Description");
			}
		}




		[SoapElement(ElementName="Link")]
		[XmlElement(ElementName="Link")]
		public String gxTpr_Link
		{
			get { 
				return gxTv_SdtK2BProgramNames_ProgramName_Link; 
			}
			set { 
				gxTv_SdtK2BProgramNames_ProgramName_Link = value;
				SetDirty("Link");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtK2BProgramNames_ProgramName_Name = "";
			gxTv_SdtK2BProgramNames_ProgramName_Description = "";
			gxTv_SdtK2BProgramNames_ProgramName_Link = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String gxTv_SdtK2BProgramNames_ProgramName_Name;
		 

		protected String gxTv_SdtK2BProgramNames_ProgramName_Description;
		 

		protected String gxTv_SdtK2BProgramNames_ProgramName_Link;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"ProgramName", Namespace="TABLEROS_WEB")]
	public class SdtK2BProgramNames_ProgramName_RESTInterface : GxGenericCollectionItem<SdtK2BProgramNames_ProgramName>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtK2BProgramNames_ProgramName_RESTInterface( ) : base()
		{
		}

		public SdtK2BProgramNames_ProgramName_RESTInterface( SdtK2BProgramNames_ProgramName psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  String gxTpr_Name
		{
			get { 
				return sdt.gxTpr_Name;

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Description", Order=1)]
		public  String gxTpr_Description
		{
			get { 
				return sdt.gxTpr_Description;

			}
			set { 
				 sdt.gxTpr_Description = value;
			}
		}

		[DataMember(Name="Link", Order=2)]
		public  String gxTpr_Link
		{
			get { 
				return sdt.gxTpr_Link;

			}
			set { 
				 sdt.gxTpr_Link = value;
			}
		}


		#endregion

		public SdtK2BProgramNames_ProgramName sdt
		{
			get { 
				return (SdtK2BProgramNames_ProgramName)Sdt;
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
				sdt = new SdtK2BProgramNames_ProgramName() ;
			}
		}
	}
	#endregion
}