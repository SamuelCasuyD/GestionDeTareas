/*
				   File: type_SdtCrearTablero_SDT
			Description: CrearTablero_SDT
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
	[XmlRoot(ElementName="CrearTablero_SDT")]
	[XmlType(TypeName="CrearTablero_SDT" , Namespace="TABLEROS_WEB" )]
	[Serializable]
	public class SdtCrearTablero_SDT : GxUserType
	{
		public SdtCrearTablero_SDT( )
		{
			/* Constructor for serialization */
			gxTv_SdtCrearTablero_SDT_Trgestiontableros_nombre = "";

			gxTv_SdtCrearTablero_SDT_Trgestiontableros_descripcion = "";

			gxTv_SdtCrearTablero_SDT_Trgestiontableros_comentario = "";

		}

		public SdtCrearTablero_SDT(IGxContext context)
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
			AddObjectProperty("TrGestionTableros_ID", gxTpr_Trgestiontableros_id, false);


			AddObjectProperty("TrGestionTableros_Nombre", gxTpr_Trgestiontableros_nombre, false);


			AddObjectProperty("TrGestionTableros_Descripcion", gxTpr_Trgestiontableros_descripcion, false);


			AddObjectProperty("TrGestionTableros_Comentario", gxTpr_Trgestiontableros_comentario, false);


			AddObjectProperty("TrGestionTableros_TipoTablero", gxTpr_Trgestiontableros_tipotablero, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontableros_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontableros_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontableros_fechainicio)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTableros_FechaInicio", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontableros_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontableros_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontableros_fechafin)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTableros_FechaFin", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontableros_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontableros_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontableros_fechacreacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTableros_FechaCreacion", sDateCnv, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Trgestiontableros_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Trgestiontableros_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Trgestiontableros_fechamodificacion)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("TrGestionTableros_FechaModificacion", sDateCnv, false);


			AddObjectProperty("TrGestionTableros_Estado", gxTpr_Trgestiontableros_estado, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TrGestionTableros_ID")]
		[XmlElement(ElementName="TrGestionTableros_ID")]
		public Guid gxTpr_Trgestiontableros_id
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_id; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_id = value;
				SetDirty("Trgestiontableros_id");
			}
		}




		[SoapElement(ElementName="TrGestionTableros_Nombre")]
		[XmlElement(ElementName="TrGestionTableros_Nombre")]
		public String gxTpr_Trgestiontableros_nombre
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_nombre; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_nombre = value;
				SetDirty("Trgestiontableros_nombre");
			}
		}




		[SoapElement(ElementName="TrGestionTableros_Descripcion")]
		[XmlElement(ElementName="TrGestionTableros_Descripcion")]
		public String gxTpr_Trgestiontableros_descripcion
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_descripcion; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_descripcion = value;
				SetDirty("Trgestiontableros_descripcion");
			}
		}




		[SoapElement(ElementName="TrGestionTableros_Comentario")]
		[XmlElement(ElementName="TrGestionTableros_Comentario")]
		public String gxTpr_Trgestiontableros_comentario
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_comentario; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_comentario = value;
				SetDirty("Trgestiontableros_comentario");
			}
		}




		[SoapElement(ElementName="TrGestionTableros_TipoTablero")]
		[XmlElement(ElementName="TrGestionTableros_TipoTablero")]
		public short gxTpr_Trgestiontableros_tipotablero
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_tipotablero; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_tipotablero = value;
				SetDirty("Trgestiontableros_tipotablero");
			}
		}



		[SoapElement(ElementName="TrGestionTableros_FechaInicio")]
		[XmlElement(ElementName="TrGestionTableros_FechaInicio" , IsNullable=true)]
		public string gxTpr_Trgestiontableros_fechainicio_Nullable
		{
			get {
				if ( gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio).value ;
			}
			set {
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontableros_fechainicio
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio = value;
				SetDirty("Trgestiontableros_fechainicio");
			}
		}


		[SoapElement(ElementName="TrGestionTableros_FechaFin")]
		[XmlElement(ElementName="TrGestionTableros_FechaFin" , IsNullable=true)]
		public string gxTpr_Trgestiontableros_fechafin_Nullable
		{
			get {
				if ( gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin).value ;
			}
			set {
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontableros_fechafin
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin = value;
				SetDirty("Trgestiontableros_fechafin");
			}
		}


		[SoapElement(ElementName="TrGestionTableros_FechaCreacion")]
		[XmlElement(ElementName="TrGestionTableros_FechaCreacion" , IsNullable=true)]
		public string gxTpr_Trgestiontableros_fechacreacion_Nullable
		{
			get {
				if ( gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion).value ;
			}
			set {
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontableros_fechacreacion
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion = value;
				SetDirty("Trgestiontableros_fechacreacion");
			}
		}


		[SoapElement(ElementName="TrGestionTableros_FechaModificacion")]
		[XmlElement(ElementName="TrGestionTableros_FechaModificacion" , IsNullable=true)]
		public string gxTpr_Trgestiontableros_fechamodificacion_Nullable
		{
			get {
				if ( gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion).value ;
			}
			set {
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[SoapIgnore]
		[XmlIgnore]
		public DateTime gxTpr_Trgestiontableros_fechamodificacion
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion = value;
				SetDirty("Trgestiontableros_fechamodificacion");
			}
		}



		[SoapElement(ElementName="TrGestionTableros_Estado")]
		[XmlElement(ElementName="TrGestionTableros_Estado")]
		public short gxTpr_Trgestiontableros_estado
		{
			get { 
				return gxTv_SdtCrearTablero_SDT_Trgestiontableros_estado; 
			}
			set { 
				gxTv_SdtCrearTablero_SDT_Trgestiontableros_estado = value;
				SetDirty("Trgestiontableros_estado");
			}
		}




		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtCrearTablero_SDT_Trgestiontableros_nombre = "";
			gxTv_SdtCrearTablero_SDT_Trgestiontableros_descripcion = "";
			gxTv_SdtCrearTablero_SDT_Trgestiontableros_comentario = "";






			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected String sDateCnv ;
		protected String sNumToPad ;
		protected Guid gxTv_SdtCrearTablero_SDT_Trgestiontableros_id;
		 

		protected String gxTv_SdtCrearTablero_SDT_Trgestiontableros_nombre;
		 

		protected String gxTv_SdtCrearTablero_SDT_Trgestiontableros_descripcion;
		 

		protected String gxTv_SdtCrearTablero_SDT_Trgestiontableros_comentario;
		 

		protected short gxTv_SdtCrearTablero_SDT_Trgestiontableros_tipotablero;
		 

		protected DateTime gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechainicio;
		 

		protected DateTime gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechafin;
		 

		protected DateTime gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechacreacion;
		 

		protected DateTime gxTv_SdtCrearTablero_SDT_Trgestiontableros_fechamodificacion;
		 

		protected short gxTv_SdtCrearTablero_SDT_Trgestiontableros_estado;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"CrearTablero_SDT", Namespace="TABLEROS_WEB")]
	public class SdtCrearTablero_SDT_RESTInterface : GxGenericCollectionItem<SdtCrearTablero_SDT>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCrearTablero_SDT_RESTInterface( ) : base()
		{
		}

		public SdtCrearTablero_SDT_RESTInterface( SdtCrearTablero_SDT psdt ) : base(psdt)
		{
		}

		#region Rest Properties
		[DataMember(Name="TrGestionTableros_ID", Order=0)]
		public Guid gxTpr_Trgestiontableros_id
		{
			get { 
				return sdt.gxTpr_Trgestiontableros_id;

			}
			set { 
				sdt.gxTpr_Trgestiontableros_id = value;
			}
		}

		[DataMember(Name="TrGestionTableros_Nombre", Order=1)]
		public  String gxTpr_Trgestiontableros_nombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Trgestiontableros_nombre);

			}
			set { 
				 sdt.gxTpr_Trgestiontableros_nombre = value;
			}
		}

		[DataMember(Name="TrGestionTableros_Descripcion", Order=2)]
		public  String gxTpr_Trgestiontableros_descripcion
		{
			get { 
				return sdt.gxTpr_Trgestiontableros_descripcion;

			}
			set { 
				 sdt.gxTpr_Trgestiontableros_descripcion = value;
			}
		}

		[DataMember(Name="TrGestionTableros_Comentario", Order=3)]
		public  String gxTpr_Trgestiontableros_comentario
		{
			get { 
				return sdt.gxTpr_Trgestiontableros_comentario;

			}
			set { 
				 sdt.gxTpr_Trgestiontableros_comentario = value;
			}
		}

		[DataMember(Name="TrGestionTableros_TipoTablero", Order=4)]
		public short gxTpr_Trgestiontableros_tipotablero
		{
			get { 
				return sdt.gxTpr_Trgestiontableros_tipotablero;

			}
			set { 
				sdt.gxTpr_Trgestiontableros_tipotablero = value;
			}
		}

		[DataMember(Name="TrGestionTableros_FechaInicio", Order=5)]
		public  String gxTpr_Trgestiontableros_fechainicio
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechainicio);

			}
			set { 
				sdt.gxTpr_Trgestiontableros_fechainicio = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTableros_FechaFin", Order=6)]
		public  String gxTpr_Trgestiontableros_fechafin
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechafin);

			}
			set { 
				sdt.gxTpr_Trgestiontableros_fechafin = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTableros_FechaCreacion", Order=7)]
		public  String gxTpr_Trgestiontableros_fechacreacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechacreacion);

			}
			set { 
				sdt.gxTpr_Trgestiontableros_fechacreacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTableros_FechaModificacion", Order=8)]
		public  String gxTpr_Trgestiontableros_fechamodificacion
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Trgestiontableros_fechamodificacion);

			}
			set { 
				sdt.gxTpr_Trgestiontableros_fechamodificacion = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="TrGestionTableros_Estado", Order=9)]
		public short gxTpr_Trgestiontableros_estado
		{
			get { 
				return sdt.gxTpr_Trgestiontableros_estado;

			}
			set { 
				sdt.gxTpr_Trgestiontableros_estado = value;
			}
		}


		#endregion

		public SdtCrearTablero_SDT sdt
		{
			get { 
				return (SdtCrearTablero_SDT)Sdt;
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
				sdt = new SdtCrearTablero_SDT() ;
			}
		}
	}
	#endregion
}