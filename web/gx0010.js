gx.evt.autoSkip=!1;gx.define("gx0010",!1,function(){var n,t;this.ServerClass="gx0010";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV9pTrGestionTableros_ID=gx.fn.getControlValue("vPTRGESTIONTABLEROS_ID")};this.Validv_Ctrgestiontableros_id=function(){return this.validCliEvt("Validv_Ctrgestiontableros_id",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTABLEROS_ID");if(this.AnyError=0,n.setAsFormatError(),!(gx.util.regExp.isMatch(this.AV6cTrGestionTableros_ID,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)")||"00000000-0000-0000-0000-000000000000"===this.AV6cTrGestionTableros_ID))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontableros_fechainicio=function(){return this.validCliEvt("Validv_Ctrgestiontableros_fechainicio",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTABLEROS_FECHAINICIO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7cTrGestionTableros_FechaInicio)===0||new gx.date.gxdate(this.AV7cTrGestionTableros_FechaInicio).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tableros_Fecha Inicio is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontableros_fechafin=function(){return this.validCliEvt("Validv_Ctrgestiontableros_fechafin",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTABLEROS_FECHAFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8cTrGestionTableros_FechaFin)===0||new gx.date.gxdate(this.AV8cTrGestionTableros_FechaFin).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tableros_Fecha Fin is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontableros_fechacreacion=function(){return this.validCliEvt("Validv_Ctrgestiontableros_fechacreacion",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTABLEROS_FECHACREACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11cTrGestionTableros_FechaCreacion)===0||new gx.date.gxdate(this.AV11cTrGestionTableros_FechaCreacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tableros_Fecha Creacion is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontableros_fechamodificacion=function(){return this.validCliEvt("Validv_Ctrgestiontableros_fechamodificacion",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTABLEROS_FECHAMODIFICACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV12cTrGestionTableros_FechaModificacion)===0||new gx.date.gxdate(this.AV12cTrGestionTableros_FechaModificacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tableros_Fecha Modificacion is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e16071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")=="AdvancedContainer"?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),gx.$.Deferred().resolve()};this.e11071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class")=="AdvancedContainerItem"?(gx.fn.setCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRGESTIONTABLEROS_ID","Visible",!0)):(gx.fn.setCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRGESTIONTABLEROS_ID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_IDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTABLEROS_ID","Visible")',ctrl:"vCTRGESTIONTABLEROS_ID",prop:"Visible"}]),gx.$.Deferred().resolve()};this.e12071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e13071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e14071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e15071_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e19072_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e20071_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,65,66,67,68,69,70,71];this.GXLastCtrlId=71;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",64,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0010",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",65,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(1,66,"TRGESTIONTABLEROS_ID","Gestion Tableros_ID","","TrGestionTableros_ID","guid",0,"px",36,36,"",null,[],1,"TrGestionTableros_ID",!0,0,!1,!0,"Attribute",1,"WWColumn");t.addSingleLineEdit(3,67,"TRGESTIONTABLEROS_FECHAINICIO","Tableros_Fecha Inicio","","TrGestionTableros_FechaInicio","date",0,"px",10,10,"right",null,[],3,"TrGestionTableros_FechaInicio",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(4,68,"TRGESTIONTABLEROS_FECHAFIN","Tableros_Fecha Fin","","TrGestionTableros_FechaFin","date",0,"px",10,10,"right",null,[],4,"TrGestionTableros_FechaFin",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TRGESTIONTABLEROS_IDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLTRGESTIONTABLEROS_IDFILTER",format:1,grid:0,evt:"e11071_client"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"guid",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontableros_id,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTABLEROS_ID",gxz:"ZV6cTrGestionTableros_ID",gxold:"OV6cTrGestionTableros_ID",gxvar:"AV6cTrGestionTableros_ID",ucs:[],op:[16],ip:[16],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cTrGestionTableros_ID=n)},v2z:function(n){n!==undefined&&(gx.O.ZV6cTrGestionTableros_ID=n)},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTABLEROS_ID",gx.O.AV6cTrGestionTableros_ID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cTrGestionTableros_ID=this.val())},val:function(){return gx.fn.getControlValue("vCTRGESTIONTABLEROS_ID")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTRGESTIONTABLEROS_FECHAINICIOFILTER",format:1,grid:0,evt:"e12071_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontableros_fechainicio,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTABLEROS_FECHAINICIO",gxz:"ZV7cTrGestionTableros_FechaInicio",gxold:"OV7cTrGestionTableros_FechaInicio",gxvar:"AV7cTrGestionTableros_FechaInicio",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cTrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cTrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTABLEROS_FECHAINICIO",gx.O.AV7cTrGestionTableros_FechaInicio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cTrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTABLEROS_FECHAINICIO")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLTRGESTIONTABLEROS_FECHAFINFILTER",format:1,grid:0,evt:"e13071_client"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontableros_fechafin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTABLEROS_FECHAFIN",gxz:"ZV8cTrGestionTableros_FechaFin",gxold:"OV8cTrGestionTableros_FechaFin",gxvar:"AV8cTrGestionTableros_FechaFin",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cTrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cTrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTABLEROS_FECHAFIN",gx.O.AV8cTrGestionTableros_FechaFin,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cTrGestionTableros_FechaFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTABLEROS_FECHAFIN")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLTRGESTIONTABLEROS_FECHACREACIONFILTER",format:1,grid:0,evt:"e14071_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontableros_fechacreacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTABLEROS_FECHACREACION",gxz:"ZV11cTrGestionTableros_FechaCreacion",gxold:"OV11cTrGestionTableros_FechaCreacion",gxvar:"AV11cTrGestionTableros_FechaCreacion",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cTrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cTrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTABLEROS_FECHACREACION",gx.O.AV11cTrGestionTableros_FechaCreacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cTrGestionTableros_FechaCreacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTABLEROS_FECHACREACION")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER",format:1,grid:0,evt:"e15071_client"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontableros_fechamodificacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",gxz:"ZV12cTrGestionTableros_FechaModificacion",gxold:"OV12cTrGestionTableros_FechaModificacion",gxvar:"AV12cTrGestionTableros_FechaModificacion",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[56],ip:[56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cTrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12cTrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTABLEROS_FECHAMODIFICACION",gx.O.AV12cTrGestionTableros_FechaModificacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12cTrGestionTableros_FechaModificacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTABLEROS_FECHAMODIFICACION")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"GRIDTABLE",grid:0};n[59]={id:59,fld:"",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"BTNTOGGLE",grid:0,evt:"e16071_client"};n[62]={id:62,fld:"",grid:0};n[63]={id:63,fld:"",grid:0};n[65]={id:65,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64),gx.O.AV5LinkSelection,gx.O.AV15Linkselection_GXI)},c2v:function(n){gx.O.AV15Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(64))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(64))},gxvar_GXI:"AV15Linkselection_GXI",nac:gx.falseFn};n[66]={id:66,lvl:2,type:"guid",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTABLEROS_ID",gxz:"Z1TrGestionTableros_ID",gxold:"O1TrGestionTableros_ID",gxvar:"A1TrGestionTableros_ID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1TrGestionTableros_ID=n)},v2z:function(n){n!==undefined&&(gx.O.Z1TrGestionTableros_ID=n)},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTABLEROS_ID",n||gx.fn.currentGridRowImpl(64),gx.O.A1TrGestionTableros_ID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1TrGestionTableros_ID=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TRGESTIONTABLEROS_ID",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[67]={id:67,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTABLEROS_FECHAINICIO",gxz:"Z3TrGestionTableros_FechaInicio",gxold:"O3TrGestionTableros_FechaInicio",gxvar:"A3TrGestionTableros_FechaInicio",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z3TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTABLEROS_FECHAINICIO",n||gx.fn.currentGridRowImpl(64),gx.O.A3TrGestionTableros_FechaInicio,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3TrGestionTableros_FechaInicio=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("TRGESTIONTABLEROS_FECHAINICIO",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[68]={id:68,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:64,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTABLEROS_FECHAFIN",gxz:"Z4TrGestionTableros_FechaFin",gxold:"O4TrGestionTableros_FechaFin",gxvar:"A4TrGestionTableros_FechaFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z4TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTABLEROS_FECHAFIN",n||gx.fn.currentGridRowImpl(64),gx.O.A4TrGestionTableros_FechaFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4TrGestionTableros_FechaFin=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("TRGESTIONTABLEROS_FECHAFIN",n||gx.fn.currentGridRowImpl(64))},nac:gx.falseFn};n[69]={id:69,fld:"",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"BTN_CANCEL",grid:0,evt:"e20071_client"};this.AV6cTrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.ZV6cTrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.OV6cTrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.AV7cTrGestionTableros_FechaInicio=gx.date.nullDate();this.ZV7cTrGestionTableros_FechaInicio=gx.date.nullDate();this.OV7cTrGestionTableros_FechaInicio=gx.date.nullDate();this.AV8cTrGestionTableros_FechaFin=gx.date.nullDate();this.ZV8cTrGestionTableros_FechaFin=gx.date.nullDate();this.OV8cTrGestionTableros_FechaFin=gx.date.nullDate();this.AV11cTrGestionTableros_FechaCreacion=gx.date.nullDate();this.ZV11cTrGestionTableros_FechaCreacion=gx.date.nullDate();this.OV11cTrGestionTableros_FechaCreacion=gx.date.nullDate();this.AV12cTrGestionTableros_FechaModificacion=gx.date.nullDate();this.ZV12cTrGestionTableros_FechaModificacion=gx.date.nullDate();this.OV12cTrGestionTableros_FechaModificacion=gx.date.nullDate();this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z1TrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.O1TrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.Z3TrGestionTableros_FechaInicio=gx.date.nullDate();this.O3TrGestionTableros_FechaInicio=gx.date.nullDate();this.Z4TrGestionTableros_FechaFin=gx.date.nullDate();this.O4TrGestionTableros_FechaFin=gx.date.nullDate();this.AV6cTrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.AV7cTrGestionTableros_FechaInicio=gx.date.nullDate();this.AV8cTrGestionTableros_FechaFin=gx.date.nullDate();this.AV11cTrGestionTableros_FechaCreacion=gx.date.nullDate();this.AV12cTrGestionTableros_FechaModificacion=gx.date.nullDate();this.AV9pTrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.A8TrGestionTableros_FechaModificacion=gx.date.nullDate();this.A7TrGestionTableros_FechaCreacion=gx.date.nullDate();this.AV5LinkSelection="";this.A1TrGestionTableros_ID="00000000-0000-0000-0000-000000000000";this.A3TrGestionTableros_FechaInicio=gx.date.nullDate();this.A4TrGestionTableros_FechaFin=gx.date.nullDate();this.Events={e19072_client:["ENTER",!0],e20071_client:["CANCEL",!0],e16071_client:["'TOGGLE'",!1],e11071_client:["LBLTRGESTIONTABLEROS_IDFILTER.CLICK",!1],e12071_client:["LBLTRGESTIONTABLEROS_FECHAINICIOFILTER.CLICK",!1],e13071_client:["LBLTRGESTIONTABLEROS_FECHAFINFILTER.CLICK",!1],e14071_client:["LBLTRGESTIONTABLEROS_FECHACREACIONFILTER.CLICK",!1],e15071_client:["LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTableros_ID",fld:"vCTRGESTIONTABLEROS_ID",pic:""},{av:"AV7cTrGestionTableros_FechaInicio",fld:"vCTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV8cTrGestionTableros_FechaFin",fld:"vCTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV11cTrGestionTableros_FechaCreacion",fld:"vCTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV12cTrGestionTableros_FechaModificacion",fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTABLEROS_IDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_IDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_IDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTABLEROS_ID","Visible")',ctrl:"vCTRGESTIONTABLEROS_ID",prop:"Visible"}]];this.EvtParms["LBLTRGESTIONTABLEROS_FECHAINICIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAINICIOFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTABLEROS_FECHAFINFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAFINFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTABLEROS_FECHACREACIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHACREACIONFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTABLEROS_FECHAMODIFICACIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTABLEROS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A1TrGestionTableros_ID",fld:"TRGESTIONTABLEROS_ID",pic:"",hsh:!0}],[{av:"AV9pTrGestionTableros_ID",fld:"vPTRGESTIONTABLEROS_ID",pic:""}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTableros_ID",fld:"vCTRGESTIONTABLEROS_ID",pic:""},{av:"AV7cTrGestionTableros_FechaInicio",fld:"vCTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV8cTrGestionTableros_FechaFin",fld:"vCTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV11cTrGestionTableros_FechaCreacion",fld:"vCTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV12cTrGestionTableros_FechaModificacion",fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTableros_ID",fld:"vCTRGESTIONTABLEROS_ID",pic:""},{av:"AV7cTrGestionTableros_FechaInicio",fld:"vCTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV8cTrGestionTableros_FechaFin",fld:"vCTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV11cTrGestionTableros_FechaCreacion",fld:"vCTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV12cTrGestionTableros_FechaModificacion",fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTableros_ID",fld:"vCTRGESTIONTABLEROS_ID",pic:""},{av:"AV7cTrGestionTableros_FechaInicio",fld:"vCTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV8cTrGestionTableros_FechaFin",fld:"vCTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV11cTrGestionTableros_FechaCreacion",fld:"vCTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV12cTrGestionTableros_FechaModificacion",fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTableros_ID",fld:"vCTRGESTIONTABLEROS_ID",pic:""},{av:"AV7cTrGestionTableros_FechaInicio",fld:"vCTRGESTIONTABLEROS_FECHAINICIO",pic:""},{av:"AV8cTrGestionTableros_FechaFin",fld:"vCTRGESTIONTABLEROS_FECHAFIN",pic:""},{av:"AV11cTrGestionTableros_FechaCreacion",fld:"vCTRGESTIONTABLEROS_FECHACREACION",pic:""},{av:"AV12cTrGestionTableros_FechaModificacion",fld:"vCTRGESTIONTABLEROS_FECHAMODIFICACION",pic:""}],[]];this.EvtParms.VALIDV_CTRGESTIONTABLEROS_ID=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTABLEROS_FECHAINICIO=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTABLEROS_FECHAFIN=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTABLEROS_FECHACREACION=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTABLEROS_FECHAMODIFICACION=[[],[]];this.setVCMap("AV9pTrGestionTableros_ID","vPTRGESTIONTABLEROS_ID",0,"guid",4,0);t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);this.Initialize()});gx.wi(function(){gx.createParentObj(gx0010)})