using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Office;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class exportwwtrgestiontableros : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("K2BOrion");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", 0);
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            if ( ! entryPointCalled )
            {
               AV10OrderedBy = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public exportwwtrgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public exportwwtrgestiontableros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( short aP0_OrderedBy )
      {
         this.AV10OrderedBy = aP0_OrderedBy;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_OrderedBy )
      {
         exportwwtrgestiontableros objexportwwtrgestiontableros;
         objexportwwtrgestiontableros = new exportwwtrgestiontableros();
         objexportwwtrgestiontableros.AV10OrderedBy = aP0_OrderedBy;
         objexportwwtrgestiontableros.context.SetSubmitInitialConfig(context);
         objexportwwtrgestiontableros.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objexportwwtrgestiontableros);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((exportwwtrgestiontableros)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTableros",  "TrGestionTableros",  "List",  "",  AV50Pgmname) )
         {
            AV11Filename = "";
            AV12ErrorMessage = "You are not authorized to do activity ";
            AV12ErrorMessage = AV12ErrorMessage + "EntityName:" + "TrGestionTableros";
            AV12ErrorMessage = AV12ErrorMessage + "TransactionName:" + "TrGestionTableros";
            AV12ErrorMessage = AV12ErrorMessage + "ActivityType:" + "List";
            AV12ErrorMessage = AV12ErrorMessage + " PgmName:" + AV50Pgmname;
            AV35HttpResponse.AddString(AV12ErrorMessage);
            context.nUserReturn = 1;
            this.cleanup();
            if (true) return;
         }
         new k2bgetcontext(context ).execute( out  AV8Context) ;
         AV33Random = (int)(NumberUtil.Random( )*10000);
         AV11Filename = GxDirectory.TemporaryFilesPath + AV36File.Separator + "ExportWWTrGestionTableros-" + StringUtil.Trim( StringUtil.Str( (decimal)(AV33Random), 8, 0)) + ".xlsx";
         /* Execute user subroutine: 'HIDESHOWCOLUMNS' */
         S121 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Open(AV11Filename);
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Clear();
         AV13ExcelDocument.AutoFit = 1;
         AV31CellRow = 1;
         AV32FirstColumn = 1;
         AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn, 1, 1).Size = 15;
         AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn, 1, 1).Bold = 1;
         AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn, 1, 1).Text = "Nombre de tableroes";
         AV31CellRow = (int)(AV31CellRow+4);
         AV31CellRow = (int)(AV31CellRow+3);
         AV34ColumnIndex = 0;
         if ( AV38GridColumnVisible_TrGestionTableros_Nombre )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Nombre ";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV39GridColumnVisible_TrGestionTableros_Comentario )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Comentario";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV40GridColumnVisible_TrGestionTableros_Descripcion )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Descripción";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV41GridColumnVisible_TrGestionTableros_TipoTablero )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Tipo";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV42GridColumnVisible_TrGestionTableros_FechaInicio )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Fecha inicio";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV43GridColumnVisible_TrGestionTableros_FechaFin )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Fecha fin";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV44GridColumnVisible_TrGestionTableros_FechaCreacion )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Fecha de creación";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV47GridColumnVisible_TrGestionTableros_FechaModificacion )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Fecha de modificación";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         if ( AV46GridColumnVisible_TrGestionTableros_Estado )
         {
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Bold = 1;
            AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = "Estado";
            AV34ColumnIndex = (short)(AV34ColumnIndex+1);
         }
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV10OrderedBy } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         } ) ;
         /* Using cursor P002H2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A6TrGestionTableros_Comentario = P002H2_A6TrGestionTableros_Comentario[0];
            n6TrGestionTableros_Comentario = P002H2_n6TrGestionTableros_Comentario[0];
            A5TrGestionTableros_Descripcion = P002H2_A5TrGestionTableros_Descripcion[0];
            n5TrGestionTableros_Descripcion = P002H2_n5TrGestionTableros_Descripcion[0];
            A9TrGestionTableros_TipoTablero = P002H2_A9TrGestionTableros_TipoTablero[0];
            n9TrGestionTableros_TipoTablero = P002H2_n9TrGestionTableros_TipoTablero[0];
            A3TrGestionTableros_FechaInicio = P002H2_A3TrGestionTableros_FechaInicio[0];
            n3TrGestionTableros_FechaInicio = P002H2_n3TrGestionTableros_FechaInicio[0];
            A4TrGestionTableros_FechaFin = P002H2_A4TrGestionTableros_FechaFin[0];
            n4TrGestionTableros_FechaFin = P002H2_n4TrGestionTableros_FechaFin[0];
            A7TrGestionTableros_FechaCreacion = P002H2_A7TrGestionTableros_FechaCreacion[0];
            n7TrGestionTableros_FechaCreacion = P002H2_n7TrGestionTableros_FechaCreacion[0];
            A8TrGestionTableros_FechaModificacion = P002H2_A8TrGestionTableros_FechaModificacion[0];
            n8TrGestionTableros_FechaModificacion = P002H2_n8TrGestionTableros_FechaModificacion[0];
            A10TrGestionTableros_Estado = P002H2_A10TrGestionTableros_Estado[0];
            n10TrGestionTableros_Estado = P002H2_n10TrGestionTableros_Estado[0];
            A2TrGestionTableros_Nombre = P002H2_A2TrGestionTableros_Nombre[0];
            n2TrGestionTableros_Nombre = P002H2_n2TrGestionTableros_Nombre[0];
            A1TrGestionTableros_ID = (Guid)((Guid)(P002H2_A1TrGestionTableros_ID[0]));
            AV31CellRow = (int)(AV31CellRow+1);
            AV34ColumnIndex = 0;
            if ( AV38GridColumnVisible_TrGestionTableros_Nombre )
            {
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = StringUtil.RTrim( A2TrGestionTableros_Nombre);
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV39GridColumnVisible_TrGestionTableros_Comentario )
            {
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = StringUtil.Substring( StringUtil.RTrim( A6TrGestionTableros_Comentario), 1, 1000);
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV40GridColumnVisible_TrGestionTableros_Descripcion )
            {
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = StringUtil.Substring( StringUtil.RTrim( A5TrGestionTableros_Descripcion), 1, 1000);
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV41GridColumnVisible_TrGestionTableros_TipoTablero )
            {
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Number = A9TrGestionTableros_TipoTablero;
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV42GridColumnVisible_TrGestionTableros_FechaInicio )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A3TrGestionTableros_FechaInicio ) ;
               AV13ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV43GridColumnVisible_TrGestionTableros_FechaFin )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A4TrGestionTableros_FechaFin ) ;
               AV13ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV44GridColumnVisible_TrGestionTableros_FechaCreacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A7TrGestionTableros_FechaCreacion ) ;
               AV13ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV47GridColumnVisible_TrGestionTableros_FechaModificacion )
            {
               GXt_dtime1 = DateTimeUtil.ResetTime( A8TrGestionTableros_FechaModificacion ) ;
               AV13ExcelDocument.SetDateFormat(context, 8, 5, 1, 2, "/", ":", " ");
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Date = GXt_dtime1;
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            if ( AV46GridColumnVisible_TrGestionTableros_Estado )
            {
               AV13ExcelDocument.get_Cells(AV31CellRow, AV32FirstColumn+AV34ColumnIndex, 1, 1).Text = (A10TrGestionTableros_Estado ? "Yes" : "No");
               AV34ColumnIndex = (short)(AV34ColumnIndex+1);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV13ExcelDocument.Save();
         /* Execute user subroutine: 'CHECKSTATUS' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         AV13ExcelDocument.Close();
         if ( ! context.isAjaxRequest( ) )
         {
            AV35HttpResponse.AppendHeader("Content-Type", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV35HttpResponse.AppendHeader("Content-Disposition", "attachment;filename=ExportWWTrGestionTableros.xlsx");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV35HttpResponse.AppendHeader("X-Frame-Options", "deny");
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV35HttpResponse.AppendHeader("X-Content-Type-Options", " nosniff");
         }
         AV35HttpResponse.AddFile(AV11Filename);
         new k2bremoveexceldocument(context).executeSubmit(  AV11Filename) ;
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'CHECKSTATUS' Routine */
         if ( AV13ExcelDocument.ErrCode != 0 )
         {
            AV11Filename = "";
            AV12ErrorMessage = AV13ExcelDocument.ErrDescription;
            AV35HttpResponse.AddString(AV12ErrorMessage);
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S121( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         /* Execute user subroutine: 'LOADAVAILABLECOLUMNS' */
         S131 ();
         if (returnInSub) return;
         new k2bloadgridcolumns(context ).execute(  "WWTrGestionTableros",  "Grid", ref  AV14GridColumns) ;
         AV37GridColumnVisible_TrGestionTableros_ID = true;
         AV38GridColumnVisible_TrGestionTableros_Nombre = true;
         AV39GridColumnVisible_TrGestionTableros_Comentario = true;
         AV40GridColumnVisible_TrGestionTableros_Descripcion = true;
         AV41GridColumnVisible_TrGestionTableros_TipoTablero = true;
         AV42GridColumnVisible_TrGestionTableros_FechaInicio = true;
         AV43GridColumnVisible_TrGestionTableros_FechaFin = true;
         AV44GridColumnVisible_TrGestionTableros_FechaCreacion = true;
         AV47GridColumnVisible_TrGestionTableros_FechaModificacion = true;
         AV46GridColumnVisible_TrGestionTableros_Estado = true;
         new k2bsavegridcolumns(context ).execute(  "WWTrGestionTableros",  "Grid",  AV14GridColumns,  false) ;
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV14GridColumns.Count )
         {
            AV15GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV14GridColumns.Item(AV52GXV1));
            if ( ! AV15GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_ID") == 0 )
               {
                  AV37GridColumnVisible_TrGestionTableros_ID = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_Nombre") == 0 )
               {
                  AV38GridColumnVisible_TrGestionTableros_Nombre = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_Comentario") == 0 )
               {
                  AV39GridColumnVisible_TrGestionTableros_Comentario = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_Descripcion") == 0 )
               {
                  AV40GridColumnVisible_TrGestionTableros_Descripcion = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_TipoTablero") == 0 )
               {
                  AV41GridColumnVisible_TrGestionTableros_TipoTablero = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaInicio") == 0 )
               {
                  AV42GridColumnVisible_TrGestionTableros_FechaInicio = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaFin") == 0 )
               {
                  AV43GridColumnVisible_TrGestionTableros_FechaFin = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaCreacion") == 0 )
               {
                  AV44GridColumnVisible_TrGestionTableros_FechaCreacion = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_FechaModificacion") == 0 )
               {
                  AV47GridColumnVisible_TrGestionTableros_FechaModificacion = false;
               }
               else if ( StringUtil.StrCmp(AV15GridColumn.gxTpr_Attributename, "TrGestionTableros_Estado") == 0 )
               {
                  AV46GridColumnVisible_TrGestionTableros_Estado = false;
               }
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
      }

      protected void S131( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         AV14GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_ID";
         AV15GridColumn.gxTpr_Columntitle = "Id tablero";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_Nombre";
         AV15GridColumn.gxTpr_Columntitle = "Nombre ";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_Comentario";
         AV15GridColumn.gxTpr_Columntitle = "Comentario";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_Descripcion";
         AV15GridColumn.gxTpr_Columntitle = "Descripción";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_TipoTablero";
         AV15GridColumn.gxTpr_Columntitle = "Tipo";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaInicio";
         AV15GridColumn.gxTpr_Columntitle = "Fecha inicio";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaFin";
         AV15GridColumn.gxTpr_Columntitle = "Fecha fin";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaCreacion";
         AV15GridColumn.gxTpr_Columntitle = "Fecha de creación";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_FechaModificacion";
         AV15GridColumn.gxTpr_Columntitle = "Fecha de modificación";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV15GridColumn.gxTpr_Attributename = "TrGestionTableros_Estado";
         AV15GridColumn.gxTpr_Columntitle = "Estado";
         AV15GridColumn.gxTpr_Showattribute = true;
         AV14GridColumns.Add(AV15GridColumn, 0);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV50Pgmname = "";
         AV11Filename = "";
         AV12ErrorMessage = "";
         AV35HttpResponse = new GxHttpResponse( context);
         AV8Context = new SdtK2BContext(context);
         AV36File = new GxFile(context.GetPhysicalPath());
         AV13ExcelDocument = new ExcelDocumentI();
         scmdbuf = "";
         P002H2_A6TrGestionTableros_Comentario = new String[] {""} ;
         P002H2_n6TrGestionTableros_Comentario = new bool[] {false} ;
         P002H2_A5TrGestionTableros_Descripcion = new String[] {""} ;
         P002H2_n5TrGestionTableros_Descripcion = new bool[] {false} ;
         P002H2_A9TrGestionTableros_TipoTablero = new short[1] ;
         P002H2_n9TrGestionTableros_TipoTablero = new bool[] {false} ;
         P002H2_A3TrGestionTableros_FechaInicio = new DateTime[] {DateTime.MinValue} ;
         P002H2_n3TrGestionTableros_FechaInicio = new bool[] {false} ;
         P002H2_A4TrGestionTableros_FechaFin = new DateTime[] {DateTime.MinValue} ;
         P002H2_n4TrGestionTableros_FechaFin = new bool[] {false} ;
         P002H2_A7TrGestionTableros_FechaCreacion = new DateTime[] {DateTime.MinValue} ;
         P002H2_n7TrGestionTableros_FechaCreacion = new bool[] {false} ;
         P002H2_A8TrGestionTableros_FechaModificacion = new DateTime[] {DateTime.MinValue} ;
         P002H2_n8TrGestionTableros_FechaModificacion = new bool[] {false} ;
         P002H2_A10TrGestionTableros_Estado = new short[1] ;
         P002H2_n10TrGestionTableros_Estado = new bool[] {false} ;
         P002H2_A2TrGestionTableros_Nombre = new String[] {""} ;
         P002H2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         P002H2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         A6TrGestionTableros_Comentario = "";
         A5TrGestionTableros_Descripcion = "";
         A3TrGestionTableros_FechaInicio = DateTime.MinValue;
         A4TrGestionTableros_FechaFin = DateTime.MinValue;
         A7TrGestionTableros_FechaCreacion = DateTime.MinValue;
         A8TrGestionTableros_FechaModificacion = DateTime.MinValue;
         A2TrGestionTableros_Nombre = "";
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         GXt_dtime1 = (DateTime)(DateTime.MinValue);
         AV14GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "TABLEROS_WEB");
         AV15GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.exportwwtrgestiontableros__default(),
            new Object[][] {
                new Object[] {
               P002H2_A6TrGestionTableros_Comentario, P002H2_n6TrGestionTableros_Comentario, P002H2_A5TrGestionTableros_Descripcion, P002H2_n5TrGestionTableros_Descripcion, P002H2_A9TrGestionTableros_TipoTablero, P002H2_n9TrGestionTableros_TipoTablero, P002H2_A3TrGestionTableros_FechaInicio, P002H2_n3TrGestionTableros_FechaInicio, P002H2_A4TrGestionTableros_FechaFin, P002H2_n4TrGestionTableros_FechaFin,
               P002H2_A7TrGestionTableros_FechaCreacion, P002H2_n7TrGestionTableros_FechaCreacion, P002H2_A8TrGestionTableros_FechaModificacion, P002H2_n8TrGestionTableros_FechaModificacion, P002H2_A10TrGestionTableros_Estado, P002H2_n10TrGestionTableros_Estado, P002H2_A2TrGestionTableros_Nombre, P002H2_n2TrGestionTableros_Nombre, P002H2_A1TrGestionTableros_ID
               }
            }
         );
         AV50Pgmname = "ExportWWTrGestionTableros";
         /* GeneXus formulas. */
         AV50Pgmname = "ExportWWTrGestionTableros";
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private short AV34ColumnIndex ;
      private short A9TrGestionTableros_TipoTablero ;
      private short A10TrGestionTableros_Estado ;
      private int AV33Random ;
      private int AV31CellRow ;
      private int AV32FirstColumn ;
      private int AV52GXV1 ;
      private String GXKey ;
      private String gxfirstwebparm ;
      private String AV50Pgmname ;
      private String scmdbuf ;
      private String A2TrGestionTableros_Nombre ;
      private DateTime GXt_dtime1 ;
      private DateTime A3TrGestionTableros_FechaInicio ;
      private DateTime A4TrGestionTableros_FechaFin ;
      private DateTime A7TrGestionTableros_FechaCreacion ;
      private DateTime A8TrGestionTableros_FechaModificacion ;
      private bool entryPointCalled ;
      private bool returnInSub ;
      private bool AV38GridColumnVisible_TrGestionTableros_Nombre ;
      private bool AV39GridColumnVisible_TrGestionTableros_Comentario ;
      private bool AV40GridColumnVisible_TrGestionTableros_Descripcion ;
      private bool AV41GridColumnVisible_TrGestionTableros_TipoTablero ;
      private bool AV42GridColumnVisible_TrGestionTableros_FechaInicio ;
      private bool AV43GridColumnVisible_TrGestionTableros_FechaFin ;
      private bool AV44GridColumnVisible_TrGestionTableros_FechaCreacion ;
      private bool AV47GridColumnVisible_TrGestionTableros_FechaModificacion ;
      private bool AV46GridColumnVisible_TrGestionTableros_Estado ;
      private bool n6TrGestionTableros_Comentario ;
      private bool n5TrGestionTableros_Descripcion ;
      private bool n9TrGestionTableros_TipoTablero ;
      private bool n3TrGestionTableros_FechaInicio ;
      private bool n4TrGestionTableros_FechaFin ;
      private bool n7TrGestionTableros_FechaCreacion ;
      private bool n8TrGestionTableros_FechaModificacion ;
      private bool n10TrGestionTableros_Estado ;
      private bool n2TrGestionTableros_Nombre ;
      private bool AV37GridColumnVisible_TrGestionTableros_ID ;
      private String A6TrGestionTableros_Comentario ;
      private String A5TrGestionTableros_Descripcion ;
      private String AV11Filename ;
      private String AV12ErrorMessage ;
      private Guid A1TrGestionTableros_ID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private String[] P002H2_A6TrGestionTableros_Comentario ;
      private bool[] P002H2_n6TrGestionTableros_Comentario ;
      private String[] P002H2_A5TrGestionTableros_Descripcion ;
      private bool[] P002H2_n5TrGestionTableros_Descripcion ;
      private short[] P002H2_A9TrGestionTableros_TipoTablero ;
      private bool[] P002H2_n9TrGestionTableros_TipoTablero ;
      private DateTime[] P002H2_A3TrGestionTableros_FechaInicio ;
      private bool[] P002H2_n3TrGestionTableros_FechaInicio ;
      private DateTime[] P002H2_A4TrGestionTableros_FechaFin ;
      private bool[] P002H2_n4TrGestionTableros_FechaFin ;
      private DateTime[] P002H2_A7TrGestionTableros_FechaCreacion ;
      private bool[] P002H2_n7TrGestionTableros_FechaCreacion ;
      private DateTime[] P002H2_A8TrGestionTableros_FechaModificacion ;
      private bool[] P002H2_n8TrGestionTableros_FechaModificacion ;
      private short[] P002H2_A10TrGestionTableros_Estado ;
      private bool[] P002H2_n10TrGestionTableros_Estado ;
      private String[] P002H2_A2TrGestionTableros_Nombre ;
      private bool[] P002H2_n2TrGestionTableros_Nombre ;
      private Guid[] P002H2_A1TrGestionTableros_ID ;
      private GxHttpResponse AV35HttpResponse ;
      private ExcelDocumentI AV13ExcelDocument ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV14GridColumns ;
      private GxFile AV36File ;
      private SdtK2BContext AV8Context ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV15GridColumn ;
   }

   public class exportwwtrgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002H2( IGxContext context ,
                                             short AV10OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         Object[] GXv_Object2 ;
         GXv_Object2 = new Object [2] ;
         scmdbuf = "SELECT [TrGestionTableros_Comentario], [TrGestionTableros_Descripcion], [TrGestionTableros_TipoTablero], [TrGestionTableros_FechaInicio], [TrGestionTableros_FechaFin], [TrGestionTableros_FechaCreacion], [TrGestionTableros_FechaModificacion], [TrGestionTableros_Estado], [TrGestionTableros_Nombre], [TrGestionTableros_ID] FROM TABLERO.[TrGestionTableros]";
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTableros_Nombre]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTableros_Nombre] DESC";
         }
         GXv_Object2[0] = scmdbuf;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002H2(context, (short)dynConstraints[0] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002H2 ;
          prmP002H2 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("P002H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002H2,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((String[]) buf[0])[0] = rslt.getLongVarchar(1) ;
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((String[]) buf[2])[0] = rslt.getLongVarchar(2) ;
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3) ;
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4) ;
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5) ;
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(6) ;
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(7) ;
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((short[]) buf[14])[0] = rslt.getShort(8) ;
                ((bool[]) buf[15])[0] = rslt.wasNull(8);
                ((String[]) buf[16])[0] = rslt.getString(9, 100) ;
                ((bool[]) buf[17])[0] = rslt.wasNull(9);
                ((Guid[]) buf[18])[0] = rslt.getGuid(10) ;
                return;
       }
    }

    public void setParameters( int cursor ,
                               IFieldSetter stmt ,
                               Object[] parms )
    {
       short sIdx ;
       switch ( cursor )
       {
       }
    }

 }

}
