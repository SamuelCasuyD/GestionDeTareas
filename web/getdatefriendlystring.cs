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
   public class getdatefriendlystring : GXProcedure
   {
      public getdatefriendlystring( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public getdatefriendlystring( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( DateTime aP0_DateTime ,
                           out String aP1_String )
      {
         this.AV8DateTime = aP0_DateTime;
         this.AV12String = "" ;
         initialize();
         executePrivate();
         aP1_String=this.AV12String;
      }

      public String executeUdp( DateTime aP0_DateTime )
      {
         execute(aP0_DateTime, out aP1_String);
         return AV12String ;
      }

      public void executeSubmit( DateTime aP0_DateTime ,
                                 out String aP1_String )
      {
         getdatefriendlystring objgetdatefriendlystring;
         objgetdatefriendlystring = new getdatefriendlystring();
         objgetdatefriendlystring.AV8DateTime = aP0_DateTime;
         objgetdatefriendlystring.AV12String = "" ;
         objgetdatefriendlystring.context.SetSubmitInitialConfig(context);
         objgetdatefriendlystring.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objgetdatefriendlystring);
         aP1_String=this.AV12String;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((getdatefriendlystring)stateInfo).executePrivate();
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
         if ( (DateTime.MinValue==AV8DateTime) )
         {
            AV12String = "";
            this.cleanup();
            if (true) return;
         }
         AV13Seconds = (long)(-DateTimeUtil.TDiff( AV8DateTime, DateTimeUtil.Now( context)));
         if ( AV13Seconds < 180 )
         {
            AV12String = "now";
         }
         else if ( AV13Seconds < 3600 )
         {
            AV11Minutes = (short)(AV13Seconds/ (decimal)(60));
            AV12String = StringUtil.Format( "%1 minutes ago", StringUtil.LTrimStr( (decimal)(AV11Minutes), 4, 0), "", "", "", "", "", "", "", "");
         }
         else if ( ( AV13Seconds >= 3600 ) && ( AV13Seconds <= 3660 ) )
         {
            AV12String = "1 hour ago";
         }
         else if ( AV13Seconds < 7200 )
         {
            AV11Minutes = (short)((AV13Seconds-3600)/ (decimal)(60));
            AV12String = StringUtil.Format( "1 hour %1 minutes ago", StringUtil.LTrimStr( (decimal)(AV11Minutes), 4, 0), "", "", "", "", "", "", "", "");
         }
         else if ( AV13Seconds < 86400 )
         {
            AV10Hours = (short)(AV13Seconds/ (decimal)(3600));
            AV11Minutes = (short)((AV13Seconds-3600*AV10Hours)/ (decimal)(60));
            AV12String = StringUtil.Format( "%1 hours %2 minutes ago", StringUtil.LTrimStr( (decimal)(AV10Hours), 4, 0), StringUtil.LTrimStr( (decimal)(AV11Minutes), 4, 0), "", "", "", "", "", "", "");
         }
         else
         {
            AV9Days = (short)(AV13Seconds/ (decimal)(86400));
            AV12String = StringUtil.Format( "%1 days ago", StringUtil.LTrimStr( (decimal)(AV9Days), 4, 0), "", "", "", "", "", "", "", "");
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

      private short AV11Minutes ;
      private short AV10Hours ;
      private short AV9Days ;
      private long AV13Seconds ;
      private String AV12String ;
      private DateTime AV8DateTime ;
      private String aP1_String ;
   }

}
