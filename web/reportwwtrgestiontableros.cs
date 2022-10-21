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
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class reportwwtrgestiontableros : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public reportwwtrgestiontableros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public reportwwtrgestiontableros( IGxContext context )
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
         reportwwtrgestiontableros objreportwwtrgestiontableros;
         objreportwwtrgestiontableros = new reportwwtrgestiontableros();
         objreportwwtrgestiontableros.AV10OrderedBy = aP0_OrderedBy;
         objreportwwtrgestiontableros.context.SetSubmitInitialConfig(context);
         objreportwwtrgestiontableros.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreportwwtrgestiontableros);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reportwwtrgestiontableros)stateInfo).executePrivate();
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
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 9, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            new k2bgetcontext(context ).execute( out  AV8Context) ;
            if ( ! new k2bisauthorizedactivityname(context).executeUdp(  "TrGestionTableros",  "TrGestionTableros",  "List",  "",  AV17Pgmname) )
            {
               H2J0( false, 30) ;
               getPrinter().GxAttris("Courier New", 20, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("You are not authorized to view this report", 148, Gx_line+-1, 849, Gx_line+31, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
            }
            else
            {
               H2J0( false, 40) ;
               getPrinter().GxDrawLine(10, Gx_line+40, 787, Gx_line+40, 0, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 26, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nombre de tableroes", 190, Gx_line+-1, 607, Gx_line+41, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+40);
               H2J0( false, 30) ;
               getPrinter().GxDrawLine(10, Gx_line+0, 787, Gx_line+0, 1, 211, 211, 211, 0) ;
               getPrinter().GxDrawLine(10, Gx_line+29, 787, Gx_line+29, 1, 211, 211, 211, 0) ;
               getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Id tablero", 10, Gx_line+8, 84, Gx_line+23, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+30);
               GxHdr3 = true;
               pr_default.dynParam(0, new Object[]{ new Object[]{
                                                    AV10OrderedBy } ,
                                                    new int[]{
                                                    TypeConstants.SHORT
                                                    }
               } ) ;
               /* Using cursor P002J2 */
               pr_default.execute(0);
               while ( (pr_default.getStatus(0) != 101) )
               {
                  A1TrGestionTableros_ID = (Guid)((Guid)(P002J2_A1TrGestionTableros_ID[0]));
                  A2TrGestionTableros_Nombre = P002J2_A2TrGestionTableros_Nombre[0];
                  n2TrGestionTableros_Nombre = P002J2_n2TrGestionTableros_Nombre[0];
                  H2J0( false, 30) ;
                  getPrinter().GxAttris("Courier New", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(A1TrGestionTableros_ID.ToString(), 10, Gx_line+7, 274, Gx_line+23, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
                  pr_default.readNext(0);
               }
               pr_default.close(0);
               GxHdr3 = false;
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H2J0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException e )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException e )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H2J0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxDrawLine(50, Gx_line+0, 775, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 383, Gx_line+33, 398, Gx_line+47, 2, 0, 0, 0) ;
                  getPrinter().GxDrawText("{{Pages}}", 417, Gx_line+33, 432, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Page", 353, Gx_line+33, 383, Gx_line+47, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("of", 400, Gx_line+33, 415, Gx_line+47, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+50);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               getPrinter().GxDrawBitMap(context.GetImagePath( "b7ea4f08-f7a5-4fad-b32e-2c1b1255fdbb", "", context.GetTheme( )), 0, Gx_line+0, 75, Gx_line+67) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.localUtil.Format( Gx_date, "99/99/99"), 608, Gx_line+0, 653, Gx_line+15, 2, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Date", 575, Gx_line+0, 608, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Page", 720, Gx_line+0, 750, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("of", 767, Gx_line+0, 782, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("{{Pages}}", 783, Gx_line+0, 798, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(Gx_page), "ZZZZZ9")), 750, Gx_line+0, 765, Gx_line+14, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+71);
               if ( GxHdr3 )
               {
                  getPrinter().GxDrawLine(10, Gx_line+0, 787, Gx_line+0, 1, 211, 211, 211, 0) ;
                  getPrinter().GxDrawLine(10, Gx_line+29, 787, Gx_line+29, 1, 211, 211, 211, 0) ;
                  getPrinter().GxAttris("Courier New", 8, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Id tablero", 10, Gx_line+8, 84, Gx_line+23, 0+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+30);
               }
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
         add_metrics2( ) ;
         add_metrics3( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Courier New", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Courier New", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics2( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      protected void add_metrics3( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
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
         AV8Context = new SdtK2BContext(context);
         AV17Pgmname = "";
         scmdbuf = "";
         P002J2_A1TrGestionTableros_ID = new Guid[] {Guid.Empty} ;
         P002J2_A2TrGestionTableros_Nombre = new String[] {""} ;
         P002J2_n2TrGestionTableros_Nombre = new bool[] {false} ;
         A1TrGestionTableros_ID = (Guid)(Guid.Empty);
         A2TrGestionTableros_Nombre = "";
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reportwwtrgestiontableros__default(),
            new Object[][] {
                new Object[] {
               P002J2_A1TrGestionTableros_ID, P002J2_A2TrGestionTableros_Nombre, P002J2_n2TrGestionTableros_Nombre
               }
            }
         );
         AV17Pgmname = "ReportWWTrGestionTableros";
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         AV17Pgmname = "ReportWWTrGestionTableros";
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV10OrderedBy ;
      private short GxWebError ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private String GXKey ;
      private String gxfirstwebparm ;
      private String AV17Pgmname ;
      private String scmdbuf ;
      private String A2TrGestionTableros_Nombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool GxHdr3 ;
      private bool n2TrGestionTableros_Nombre ;
      private Guid A1TrGestionTableros_ID ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P002J2_A1TrGestionTableros_ID ;
      private String[] P002J2_A2TrGestionTableros_Nombre ;
      private bool[] P002J2_n2TrGestionTableros_Nombre ;
      private SdtK2BContext AV8Context ;
   }

   public class reportwwtrgestiontableros__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002J2( IGxContext context ,
                                             short AV10OrderedBy )
      {
         String sWhereString = "" ;
         String scmdbuf ;
         Object[] GXv_Object1 ;
         GXv_Object1 = new Object [2] ;
         scmdbuf = "SELECT [TrGestionTableros_ID], [TrGestionTableros_Nombre] FROM TABLERO.[TrGestionTableros]";
         if ( AV10OrderedBy == 0 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTableros_Nombre]";
         }
         else if ( AV10OrderedBy == 1 )
         {
            scmdbuf = scmdbuf + " ORDER BY [TrGestionTableros_Nombre] DESC";
         }
         GXv_Object1[0] = scmdbuf;
         return GXv_Object1 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002J2(context, (short)dynConstraints[0] );
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
          Object[] prmP002J2 ;
          prmP002J2 = new Object[] {
          } ;
          def= new CursorDef[] {
              new CursorDef("P002J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002J2,100, GxCacheFrequency.OFF ,false,false )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1) ;
                ((String[]) buf[1])[0] = rslt.getString(2, 100) ;
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
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
