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
   public class k2bsavegridcolumns : GXProcedure
   {
      public k2bsavegridcolumns( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public k2bsavegridcolumns( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( String aP0_ProgramName ,
                           String aP1_GridName ,
                           GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridState ,
                           bool aP3_PersistInDB )
      {
         this.AV12ProgramName = aP0_ProgramName;
         this.AV8GridName = aP1_GridName;
         this.AV9GridState = aP2_GridState;
         this.AV11PersistInDB = aP3_PersistInDB;
         initialize();
         executePrivate();
      }

      public void executeSubmit( String aP0_ProgramName ,
                                 String aP1_GridName ,
                                 GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> aP2_GridState ,
                                 bool aP3_PersistInDB )
      {
         k2bsavegridcolumns objk2bsavegridcolumns;
         objk2bsavegridcolumns = new k2bsavegridcolumns();
         objk2bsavegridcolumns.AV12ProgramName = aP0_ProgramName;
         objk2bsavegridcolumns.AV8GridName = aP1_GridName;
         objk2bsavegridcolumns.AV9GridState = aP2_GridState;
         objk2bsavegridcolumns.AV11PersistInDB = aP3_PersistInDB;
         objk2bsavegridcolumns.context.SetSubmitInitialConfig(context);
         objk2bsavegridcolumns.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objk2bsavegridcolumns);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((k2bsavegridcolumns)stateInfo).executePrivate();
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
         AV15SessionKey = StringUtil.Trim( AV12ProgramName) + "#" + StringUtil.Trim( AV8GridName) + "GridColumns";
         AV14SessionString = AV13Session.Get(AV15SessionKey);
         AV10NewSessionString = AV9GridState.ToJSonString(false);
         if ( StringUtil.StrCmp(AV14SessionString, AV10NewSessionString) != 0 )
         {
            AV13Session.Set(AV15SessionKey, AV10NewSessionString);
            if ( AV11PersistInDB )
            {
               new k2bpersistgridcolumns(context ).execute(  AV12ProgramName,  AV8GridName,  AV9GridState) ;
            }
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
         AV15SessionKey = "";
         AV14SessionString = "";
         AV13Session = context.GetSession();
         AV10NewSessionString = "";
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private String AV12ProgramName ;
      private String AV8GridName ;
      private String AV15SessionKey ;
      private String AV14SessionString ;
      private String AV10NewSessionString ;
      private bool AV11PersistInDB ;
      private IGxSession AV13Session ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV9GridState ;
   }

}
