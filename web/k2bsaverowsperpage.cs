using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
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
   public class k2bsaverowsperpage : GXProcedure
   {
      public k2bsaverowsperpage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsaverowsperpage( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_GridName ,
                           short aP2_RowsPerPage )
      {
         this.AV10ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV11RowsPerPage = aP2_RowsPerPage;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_GridName ,
                                 short aP2_RowsPerPage )
      {
         k2bsaverowsperpage objk2bsaverowsperpage;
         objk2bsaverowsperpage = new k2bsaverowsperpage();
         objk2bsaverowsperpage.AV10ProgramName = aP0_ProgramName;
         objk2bsaverowsperpage.AV8GridName = aP1_GridName;
         objk2bsaverowsperpage.AV11RowsPerPage = aP2_RowsPerPage;
         objk2bsaverowsperpage.context.SetSubmitInitialConfig(context);
         objk2bsaverowsperpage.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsaverowsperpage);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsaverowsperpage)stateInfo).executePrivate();
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
         AV13SessionString = AV12Session.Get(StringUtil.Trim( AV10ProgramName)+StringUtil.Trim( AV8GridName)+"RowsPerPage");
         AV9NewSessionString = StringUtil.Str( (decimal)(AV11RowsPerPage), 4, 0);
         if ( StringUtil.StrCmp(AV13SessionString, AV9NewSessionString) != 0 )
         {
            AV12Session.Set(StringUtil.Trim( AV10ProgramName)+StringUtil.Trim( AV8GridName)+"RowsPerPage", StringUtil.Trim( StringUtil.Str( (decimal)(AV11RowsPerPage), 4, 0)));
            new k2bpersistrowsperpage(context ).execute(  AV10ProgramName,  AV8GridName,  AV11RowsPerPage) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         AV13SessionString = "";
         AV12Session = context.GetSession();
         AV9NewSessionString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11RowsPerPage ;
      private String AV8GridName ;
      private String AV13SessionString ;
      private String AV9NewSessionString ;
      private String AV10ProgramName ;
      private IGxSession AV12Session ;
   }

}
