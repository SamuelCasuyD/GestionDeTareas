/*
				   File: type_SdtGestionEtiquetas_SDT
			Description: GestionEtiquetas_SDT
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
	[XmlRoot(ElementName="GestionEtiquetas_SDT")]
	[XmlType(TypeName="GestionEtiquetas_SDT" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtGestionEtiquetas_SDT : GxUserType
	{
		public SdtGestionEtiquetas_SDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_nombre = "";

		}

		public SdtGestionEtiquetas_SDT(IGxContext context)
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
			AddObjectProperty("TrEtiquetas_ID", gxTpr_Tretiquetas_id, false);


			AddObjectProperty("TrEtiquetas_IDTarea", gxTpr_Tretiquetas_idtarea, false);


			AddObjectProperty("TrEtiquetas_Nombre", gxTpr_Tretiquetas_nombre, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tretiquetas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tretiquetas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tretiquetas_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrEtiquetas_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Tretiquetas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Tretiquetas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Tretiquetas_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrEtiquetas_FechaModificacion", sDateCnv, false);


			AddObjectProperty("TrEtiquetas_Estado", gxTpr_Tretiquetas_estado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrEtiquetas_ID")]
		[XmlElement(ElementName="TrEtiquetas_ID")]
		public long gxTpr_Tretiquetas_id
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_id; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_id = value;
				SetDirty("Tretiquetas_id");
			}
		}




		[SoapElement(ElementName="TrEtiquetas_IDTarea")]
		[XmlElement(ElementName="TrEtiquetas_IDTarea")]
		public long gxTpr_Tretiquetas_idtarea
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_idtarea; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_idtarea = value;
				SetDirty("Tretiquetas_idtarea");
			}
		}




		[SoapElement(ElementName="TrEtiquetas_Nombre")]
		[XmlElement(ElementName="TrEtiquetas_Nombre")]
		public String gxTpr_Tretiquetas_nombre
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_nombre; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_nombre = value;
				SetDirty("Tretiquetas_nombre");
			}
		}



		[SoapElement(ElementName="TrEtiquetas_FechaCreacion")]
		[XmlElement(ElementName="TrEtiquetas_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Tretiquetas_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion).value ;
			}
			set {
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tretiquetas_fechacreacion
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion = value;
				SetDirty("Tretiquetas_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrEtiquetas_FechaModificacion")]
		[XmlElement(ElementName="TrEtiquetas_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Tretiquetas_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion).value ;
			}
			set {
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Tretiquetas_fechamodificacion
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion = value;
				SetDirty("Tretiquetas_fechamodificacion");
			}
		}



		[SoapElement(ElementName="TrEtiquetas_Estado")]
		[XmlElement(ElementName="TrEtiquetas_Estado")]
		public short gxTpr_Tretiquetas_estado
		{
			get { 
				return gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_estado; 
			}
			set { 
				gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_estado = value;
				SetDirty("Tretiquetas_estado");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_nombre = "";



			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String sDateCnv ;
		protected String sNumToPad ;
		protected long gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_id;
		 

		protected long gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_idtarea;
		 

		protected String gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_nombre;
		 

		protected DateTime gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechacreacion;
		 

		protected DateTime gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_fechamodificacion;
		 

		protected short gxTv_SdtGestionEtiquetas_SDT_Tretiquetas_estado;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"GestionEtiquetas_SDT", Namespace="TABLEROS_WEB")]
	public class SdtGestionEtiquetas_SDT_RESTInterface : GxGenericCollectionItem<SdtGestionEtiquetas_SDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtGestionEtiquetas_SDT_RESTInterface( ) : base()
		{
		}

		public SdtGestionEtiquetas_SDT_RESTInterface( SdtGestionEtiquetas_SDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TrEtiquetas_ID", Order=0)]
		public  String gxTpr_Tretiquetas_id
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tretiquetas_id, 13, 0));

			}
			set { 
				sdt.gxTpr_Tretiquetas_id = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrEtiquetas_IDTarea", Order=1)]
		public  String gxTpr_Tretiquetas_idtarea
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str( (decimal) sdt.gxTpr_Tretiquetas_idtarea, 13, 0));

			}
			set { 
				sdt.gxTpr_Tretiquetas_idtarea = (long) NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TrEtiquetas_Nombre", Order=2)]
		public  String gxTpr_Tretiquetas_nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tretiquetas_nombre);

			}
			set { 
				 sdt.gxTpr_Tretiquetas_nombre = value;
			}
		}

		[DataMember(Name="TrEtiquetas_FechaCreacion", Order=3)]
		public  String gxTpr_Tretiquetas_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tretiquetas_fechacreacion);

			}
			set { 
				sdt.gxTpr_Tretiquetas_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrEtiquetas_FechaModificacion", Order=4)]
		public  String gxTpr_Tretiquetas_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Tretiquetas_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Tretiquetas_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrEtiquetas_Estado", Order=5)]
		public short gxTpr_Tretiquetas_estado
		{
			get { 
				return sdt.gxTpr_Tretiquetas_estado;

			}
			set { 
				sdt.gxTpr_Tretiquetas_estado = value;
			}
		}


		#endregion

		public SdtGestionEtiquetas_SDT sdt
		{
			get { 
				return (SdtGestionEtiquetas_SDT)Sdt;
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
				sdt = new SdtGestionEtiquetas_SDT() ;
			}
		}
	}
	#endregion
}