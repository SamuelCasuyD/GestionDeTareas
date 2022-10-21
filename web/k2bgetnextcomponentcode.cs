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
   public class k2bgetnextcomponentcode : GXProcedure
   {
      public k2bgetnextcomponentcode( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bgetnextcomponentcode( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( GxSimpleCollection<String> aP0_AvailableTabs ,
                           String aP1_TabCode ,
                           out String aP2_NextTab )
      {
         this.AV8AvailableTabs = aP0_AvailableTabs;
         this.AV9TabCode = aP1_TabCode;
         this.AV10NextTab = "" ;
         initialize();
         executePrivate();
         aP2_NextTab=this.AV10NextTab;
      }

      public String executeUdp( GxSimpleCollection<String> aP0_AvailableTabs ,
                                String aP1_TabCode )
      {
         execute(aP0_AvailableTabs, aP1_TabCode, out aP2_NextTab);
         return AV10NextTab ;
      }

      public void executeSubmit( GxSimpleCollection<String> aP0_AvailableTabs ,
                                 String aP1_TabCode ,
                                 out String aP2_NextTab )
      {
         k2bgetnextcomponentcode objk2bgetnextcomponentcode;
         objk2bgetnextcomponentcode = new k2bgetnextcomponentcode();
         objk2bgetnextcomponentcode.AV8AvailableTabs = aP0_AvailableTabs;
         objk2bgetnextcomponentcode.AV9TabCode = aP1_TabCode;
         objk2bgetnextcomponentcode.AV10NextTab = "" ;
         objk2bgetnextcomponentcode.context.SetSubmitInitialConfig(context);
         objk2bgetnextcomponentcode.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bgetnextcomponentcode);
         aP2_NextTab=this.AV10NextTab;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bgetnextcomponentcode)stateInfo).executePrivate();
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
         AV10NextTab = "";
         AV11i = 1;
         while ( AV11i < AV8AvailableTabs.Count )
         {
            if ( ( StringUtil.StrCmp(AV8AvailableTabs.GetString(AV11i), AV9TabCode) == 0 ) || ( StringUtil.StrCmp(AV9TabCode, "") == 0 ) )
            {
               AV10NextTab = AV8AvailableTabs.GetString(AV11i+1);
               if (true) break;
            }
            AV11i = (short)(AV11i+1);
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11i ;
      private String AV9TabCode ;
      private String AV10NextTab ;
      private String aP2_NextTab ;
      private GxSimpleCollection<String> AV8AvailableTabs ;
   }

}
