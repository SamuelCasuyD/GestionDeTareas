gx.evt.autoSkip=!1;gx.define("gx0020",!1,function(){var n,t;this.ServerClass="gx0020";this.PackageName="GeneXus.Programs";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV12pTrGestionTareas_ID=gx.fn.getIntegerValue("vPTRGESTIONTAREAS_ID",",")};this.Validv_Ctrgestiontareas_idtablero=function(){return this.validCliEvt("Validv_Ctrgestiontareas_idtablero",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_IDTABLERO");if(this.AnyError=0,n.setAsFormatError(),!(gx.util.regExp.isMatch(this.AV7cTrGestionTareas_IDTablero,"([0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}|^\\s*$)")||"00000000-0000-0000-0000-000000000000"===this.AV7cTrGestionTareas_IDTablero))try{n.setError("GXM_InvalidGUID");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontareas_fechainicio=function(){return this.validCliEvt("Validv_Ctrgestiontareas_fechainicio",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_FECHAINICIO");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV8cTrGestionTareas_FechaInicio)===0||new gx.date.gxdate(this.AV8cTrGestionTareas_FechaInicio).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tareas_Fecha Inicio is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontareas_fechafin=function(){return this.validCliEvt("Validv_Ctrgestiontareas_fechafin",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_FECHAFIN");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV9cTrGestionTareas_FechaFin)===0||new gx.date.gxdate(this.AV9cTrGestionTareas_FechaFin).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tareas_Fecha Fin is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontareas_fechacreacion=function(){return this.validCliEvt("Validv_Ctrgestiontareas_fechacreacion",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_FECHACREACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV10cTrGestionTareas_FechaCreacion)===0||new gx.date.gxdate(this.AV10cTrGestionTareas_FechaCreacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tareas_Fecha Creacion is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontareas_fechamodificacion=function(){return this.validCliEvt("Validv_Ctrgestiontareas_fechamodificacion",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_FECHAMODIFICACION");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV11cTrGestionTareas_FechaModificacion)===0||new gx.date.gxdate(this.AV11cTrGestionTareas_FechaModificacion).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Tr Gestion Tareas_Fecha Modificacion is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Validv_Ctrgestiontareas_estado=function(){return this.validCliEvt("Validv_Ctrgestiontareas_estado",0,function(){try{var n=gx.util.balloon.getNew("vCTRGESTIONTAREAS_ESTADO");if(this.AnyError=0,!(this.AV14cTrGestionTareas_Estado==1||this.AV14cTrGestionTareas_Estado==2||this.AV14cTrGestionTareas_Estado==3||this.AV14cTrGestionTareas_Estado==4||this.AV14cTrGestionTareas_Estado==5||0===this.AV14cTrGestionTareas_Estado))try{n.setError("Field Tr Gestion Tareas_Estado is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e18081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")=="AdvancedContainer"?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),gx.$.Deferred().resolve()};this.e11081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class")=="AdvancedContainerItem"?(gx.fn.setCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_ID","Visible",!0)):(gx.fn.setCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_ID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTAREAS_ID","Visible")',ctrl:"vCTRGESTIONTAREAS_ID",prop:"Visible"}]),gx.$.Deferred().resolve()};this.e12081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class")=="AdvancedContainerItem"?(gx.fn.setCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_IDTABLERO","Visible",!0)):(gx.fn.setCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_IDTABLERO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTAREAS_IDTABLERO","Visible")',ctrl:"vCTRGESTIONTAREAS_IDTABLERO",prop:"Visible"}]),gx.$.Deferred().resolve()};this.e13081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e14081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAFINFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e15081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e16081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class")=="AdvancedContainerItem"?gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}]),gx.$.Deferred().resolve()};this.e17081_client=function(){return this.clearMessages(),gx.fn.getCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class")=="AdvancedContainerItem"?(gx.fn.setCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_ESTADO","Visible",!0)):(gx.fn.setCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTRGESTIONTAREAS_ESTADO","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_ESTADOFILTERCONTAINER",prop:"Class"},{ctrl:"vCTRGESTIONTAREAS_ESTADO"}]),gx.$.Deferred().resolve()};this.e21082_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e22081_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92];this.GXLastCtrlId=92;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0020",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(12,86,"TRGESTIONTAREAS_ID","Gestion Tareas_ID","","TrGestionTareas_ID","int",0,"px",13,13,"right",null,[],12,"TrGestionTareas_ID",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(11,87,"TRGESTIONTAREAS_IDTABLERO","Gestion Tareas_IDTablero","","TrGestionTareas_IDTablero","guid",0,"px",36,36,"",null,[],11,"TrGestionTareas_IDTablero",!0,0,!1,!0,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(15,88,"TRGESTIONTAREAS_FECHAINICIO","Tareas_Fecha Inicio","","TrGestionTareas_FechaInicio","date",0,"px",10,10,"right",null,[],15,"TrGestionTareas_FechaInicio",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(16,89,"TRGESTIONTAREAS_FECHAFIN","Tareas_Fecha Fin","","TrGestionTareas_FechaFin","date",0,"px",10,10,"right",null,[],16,"TrGestionTareas_FechaFin",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TRGESTIONTAREAS_IDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLTRGESTIONTAREAS_IDFILTER",format:1,grid:0,evt:"e11081_client"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:13,dec:0,sign:!1,pic:"ZZZZZZZZZZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_ID",gxz:"ZV6cTrGestionTareas_ID",gxold:"OV6cTrGestionTareas_ID",gxvar:"AV6cTrGestionTareas_ID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cTrGestionTareas_ID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cTrGestionTareas_ID=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_ID",gx.O.AV6cTrGestionTareas_ID,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cTrGestionTareas_ID=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTRGESTIONTAREAS_ID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLTRGESTIONTAREAS_IDTABLEROFILTER",format:1,grid:0,evt:"e12081_client"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"guid",len:4,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_idtablero,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_IDTABLERO",gxz:"ZV7cTrGestionTareas_IDTablero",gxold:"OV7cTrGestionTareas_IDTablero",gxvar:"AV7cTrGestionTareas_IDTablero",ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cTrGestionTareas_IDTablero=n)},v2z:function(n){n!==undefined&&(gx.O.ZV7cTrGestionTareas_IDTablero=n)},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_IDTABLERO",gx.O.AV7cTrGestionTareas_IDTablero,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cTrGestionTareas_IDTablero=this.val())},val:function(){return gx.fn.getControlValue("vCTRGESTIONTAREAS_IDTABLERO")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLTRGESTIONTAREAS_FECHAINICIOFILTER",format:1,grid:0,evt:"e13081_client"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_fechainicio,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_FECHAINICIO",gxz:"ZV8cTrGestionTareas_FechaInicio",gxold:"OV8cTrGestionTareas_FechaInicio",gxvar:"AV8cTrGestionTareas_FechaInicio",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[36],ip:[36],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cTrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cTrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_FECHAINICIO",gx.O.AV8cTrGestionTareas_FechaInicio,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cTrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTAREAS_FECHAINICIO")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"TRGESTIONTAREAS_FECHAFINFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLTRGESTIONTAREAS_FECHAFINFILTER",format:1,grid:0,evt:"e14081_client"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_fechafin,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_FECHAFIN",gxz:"ZV9cTrGestionTareas_FechaFin",gxold:"OV9cTrGestionTareas_FechaFin",gxvar:"AV9cTrGestionTareas_FechaFin",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[46],ip:[46],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cTrGestionTareas_FechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cTrGestionTareas_FechaFin=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_FECHAFIN",gx.O.AV9cTrGestionTareas_FechaFin,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cTrGestionTareas_FechaFin=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTAREAS_FECHAFIN")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLTRGESTIONTAREAS_FECHACREACIONFILTER",format:1,grid:0,evt:"e15081_client"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_fechacreacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_FECHACREACION",gxz:"ZV10cTrGestionTareas_FechaCreacion",gxold:"OV10cTrGestionTareas_FechaCreacion",gxvar:"AV10cTrGestionTareas_FechaCreacion",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[56],ip:[56],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cTrGestionTareas_FechaCreacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cTrGestionTareas_FechaCreacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_FECHACREACION",gx.O.AV10cTrGestionTareas_FechaCreacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cTrGestionTareas_FechaCreacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTAREAS_FECHACREACION")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER",format:1,grid:0,evt:"e16081_client"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"date",len:10,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_fechamodificacion,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",gxz:"ZV11cTrGestionTareas_FechaModificacion",gxold:"OV11cTrGestionTareas_FechaModificacion",gxvar:"AV11cTrGestionTareas_FechaModificacion",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[66],ip:[66],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cTrGestionTareas_FechaModificacion=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cTrGestionTareas_FechaModificacion=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCTRGESTIONTAREAS_FECHAMODIFICACION",gx.O.AV11cTrGestionTareas_FechaModificacion,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cTrGestionTareas_FechaModificacion=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCTRGESTIONTAREAS_FECHAMODIFICACION")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"TRGESTIONTAREAS_ESTADOFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLTRGESTIONTAREAS_ESTADOFILTER",format:1,grid:0,evt:"e17081_client"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:this.Validv_Ctrgestiontareas_estado,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTRGESTIONTAREAS_ESTADO",gxz:"ZV14cTrGestionTareas_Estado",gxold:"OV14cTrGestionTareas_Estado",gxvar:"AV14cTrGestionTareas_Estado",ucs:[],op:[76],ip:[76],nacdep:[],ctrltype:"combo",v2v:function(n){n!==undefined&&(gx.O.AV14cTrGestionTareas_Estado=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV14cTrGestionTareas_Estado=gx.num.intval(n))},v2c:function(){gx.fn.setComboBoxValue("vCTRGESTIONTAREAS_ESTADO",gx.O.AV14cTrGestionTareas_Estado)},c2v:function(){this.val()!==undefined&&(gx.O.AV14cTrGestionTareas_Estado=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTRGESTIONTAREAS_ESTADO",",")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e18081_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV17Linkselection_GXI)},c2v:function(n){gx.O.AV17Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV17Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"int",len:13,dec:0,sign:!1,pic:"ZZZZZZZZZZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTAREAS_ID",gxz:"Z12TrGestionTareas_ID",gxold:"O12TrGestionTareas_ID",gxvar:"A12TrGestionTareas_ID",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A12TrGestionTareas_ID=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z12TrGestionTareas_ID=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTAREAS_ID",n||gx.fn.currentGridRowImpl(84),gx.O.A12TrGestionTareas_ID,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12TrGestionTareas_ID=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TRGESTIONTAREAS_ID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"guid",len:4,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTAREAS_IDTABLERO",gxz:"Z11TrGestionTareas_IDTablero",gxold:"O11TrGestionTareas_IDTablero",gxvar:"A11TrGestionTareas_IDTablero",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A11TrGestionTareas_IDTablero=n)},v2z:function(n){n!==undefined&&(gx.O.Z11TrGestionTareas_IDTablero=n)},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTAREAS_IDTABLERO",n||gx.fn.currentGridRowImpl(84),gx.O.A11TrGestionTareas_IDTablero,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A11TrGestionTareas_IDTablero=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TRGESTIONTAREAS_IDTABLERO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTAREAS_FECHAINICIO",gxz:"Z15TrGestionTareas_FechaInicio",gxold:"O15TrGestionTareas_FechaInicio",gxvar:"A15TrGestionTareas_FechaInicio",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A15TrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z15TrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTAREAS_FECHAINICIO",n||gx.fn.currentGridRowImpl(84),gx.O.A15TrGestionTareas_FechaInicio,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15TrGestionTareas_FechaInicio=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("TRGESTIONTAREAS_FECHAINICIO",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"date",len:10,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TRGESTIONTAREAS_FECHAFIN",gxz:"Z16TrGestionTareas_FechaFin",gxold:"O16TrGestionTareas_FechaFin",gxvar:"A16TrGestionTareas_FechaFin",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/9999",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16TrGestionTareas_FechaFin=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z16TrGestionTareas_FechaFin=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("TRGESTIONTAREAS_FECHAFIN",n||gx.fn.currentGridRowImpl(84),gx.O.A16TrGestionTareas_FechaFin,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16TrGestionTareas_FechaFin=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("TRGESTIONTAREAS_FECHAFIN",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[90]={id:90,fld:"",grid:0};n[91]={id:91,fld:"",grid:0};n[92]={id:92,fld:"BTN_CANCEL",grid:0,evt:"e22081_client"};this.AV6cTrGestionTareas_ID=0;this.ZV6cTrGestionTareas_ID=0;this.OV6cTrGestionTareas_ID=0;this.AV7cTrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.ZV7cTrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.OV7cTrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.AV8cTrGestionTareas_FechaInicio=gx.date.nullDate();this.ZV8cTrGestionTareas_FechaInicio=gx.date.nullDate();this.OV8cTrGestionTareas_FechaInicio=gx.date.nullDate();this.AV9cTrGestionTareas_FechaFin=gx.date.nullDate();this.ZV9cTrGestionTareas_FechaFin=gx.date.nullDate();this.OV9cTrGestionTareas_FechaFin=gx.date.nullDate();this.AV10cTrGestionTareas_FechaCreacion=gx.date.nullDate();this.ZV10cTrGestionTareas_FechaCreacion=gx.date.nullDate();this.OV10cTrGestionTareas_FechaCreacion=gx.date.nullDate();this.AV11cTrGestionTareas_FechaModificacion=gx.date.nullDate();this.ZV11cTrGestionTareas_FechaModificacion=gx.date.nullDate();this.OV11cTrGestionTareas_FechaModificacion=gx.date.nullDate();this.AV14cTrGestionTareas_Estado=0;this.ZV14cTrGestionTareas_Estado=0;this.OV14cTrGestionTareas_Estado=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z12TrGestionTareas_ID=0;this.O12TrGestionTareas_ID=0;this.Z11TrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.O11TrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.Z15TrGestionTareas_FechaInicio=gx.date.nullDate();this.O15TrGestionTareas_FechaInicio=gx.date.nullDate();this.Z16TrGestionTareas_FechaFin=gx.date.nullDate();this.O16TrGestionTareas_FechaFin=gx.date.nullDate();this.AV6cTrGestionTareas_ID=0;this.AV7cTrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.AV8cTrGestionTareas_FechaInicio=gx.date.nullDate();this.AV9cTrGestionTareas_FechaFin=gx.date.nullDate();this.AV10cTrGestionTareas_FechaCreacion=gx.date.nullDate();this.AV11cTrGestionTareas_FechaModificacion=gx.date.nullDate();this.AV14cTrGestionTareas_Estado=0;this.AV12pTrGestionTareas_ID=0;this.A24TrGestionTareas_Estado=0;this.A18TrGestionTareas_FechaModificacion=gx.date.nullDate();this.A17TrGestionTareas_FechaCreacion=gx.date.nullDate();this.AV5LinkSelection="";this.A12TrGestionTareas_ID=0;this.A11TrGestionTareas_IDTablero="00000000-0000-0000-0000-000000000000";this.A15TrGestionTareas_FechaInicio=gx.date.nullDate();this.A16TrGestionTareas_FechaFin=gx.date.nullDate();this.Events={e21082_client:["ENTER",!0],e22081_client:["CANCEL",!0],e18081_client:["'TOGGLE'",!1],e11081_client:["LBLTRGESTIONTAREAS_IDFILTER.CLICK",!1],e12081_client:["LBLTRGESTIONTAREAS_IDTABLEROFILTER.CLICK",!1],e13081_client:["LBLTRGESTIONTAREAS_FECHAINICIOFILTER.CLICK",!1],e14081_client:["LBLTRGESTIONTAREAS_FECHAFINFILTER.CLICK",!1],e15081_client:["LBLTRGESTIONTAREAS_FECHACREACIONFILTER.CLICK",!1],e16081_client:["LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER.CLICK",!1],e17081_client:["LBLTRGESTIONTAREAS_ESTADOFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTareas_ID",fld:"vCTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"},{av:"AV7cTrGestionTareas_IDTablero",fld:"vCTRGESTIONTAREAS_IDTABLERO",pic:""},{av:"AV8cTrGestionTareas_FechaInicio",fld:"vCTRGESTIONTAREAS_FECHAINICIO",pic:""},{av:"AV9cTrGestionTareas_FechaFin",fld:"vCTRGESTIONTAREAS_FECHAFIN",pic:""},{av:"AV10cTrGestionTareas_FechaCreacion",fld:"vCTRGESTIONTAREAS_FECHACREACION",pic:""},{av:"AV11cTrGestionTareas_FechaModificacion",fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",pic:""},{ctrl:"vCTRGESTIONTAREAS_ESTADO"},{av:"AV14cTrGestionTareas_Estado",fld:"vCTRGESTIONTAREAS_ESTADO",pic:"ZZZ9"}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTAREAS_IDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTAREAS_ID","Visible")',ctrl:"vCTRGESTIONTAREAS_ID",prop:"Visible"}]];this.EvtParms["LBLTRGESTIONTAREAS_IDTABLEROFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_IDTABLEROFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTRGESTIONTAREAS_IDTABLERO","Visible")',ctrl:"vCTRGESTIONTAREAS_IDTABLERO",prop:"Visible"}]];this.EvtParms["LBLTRGESTIONTAREAS_FECHAINICIOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAINICIOFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTAREAS_FECHAFINFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAFINFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAFINFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAFINFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTAREAS_FECHACREACIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHACREACIONFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTAREAS_FECHAMODIFICACIONFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_FECHAMODIFICACIONFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLTRGESTIONTAREAS_ESTADOFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_ESTADOFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TRGESTIONTAREAS_ESTADOFILTERCONTAINER","Class")',ctrl:"TRGESTIONTAREAS_ESTADOFILTERCONTAINER",prop:"Class"},{ctrl:"vCTRGESTIONTAREAS_ESTADO"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A12TrGestionTareas_ID",fld:"TRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9",hsh:!0}],[{av:"AV12pTrGestionTareas_ID",fld:"vPTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTareas_ID",fld:"vCTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"},{av:"AV7cTrGestionTareas_IDTablero",fld:"vCTRGESTIONTAREAS_IDTABLERO",pic:""},{av:"AV8cTrGestionTareas_FechaInicio",fld:"vCTRGESTIONTAREAS_FECHAINICIO",pic:""},{av:"AV9cTrGestionTareas_FechaFin",fld:"vCTRGESTIONTAREAS_FECHAFIN",pic:""},{av:"AV10cTrGestionTareas_FechaCreacion",fld:"vCTRGESTIONTAREAS_FECHACREACION",pic:""},{av:"AV11cTrGestionTareas_FechaModificacion",fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",pic:""},{ctrl:"vCTRGESTIONTAREAS_ESTADO"},{av:"AV14cTrGestionTareas_Estado",fld:"vCTRGESTIONTAREAS_ESTADO",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTareas_ID",fld:"vCTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"},{av:"AV7cTrGestionTareas_IDTablero",fld:"vCTRGESTIONTAREAS_IDTABLERO",pic:""},{av:"AV8cTrGestionTareas_FechaInicio",fld:"vCTRGESTIONTAREAS_FECHAINICIO",pic:""},{av:"AV9cTrGestionTareas_FechaFin",fld:"vCTRGESTIONTAREAS_FECHAFIN",pic:""},{av:"AV10cTrGestionTareas_FechaCreacion",fld:"vCTRGESTIONTAREAS_FECHACREACION",pic:""},{av:"AV11cTrGestionTareas_FechaModificacion",fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",pic:""},{ctrl:"vCTRGESTIONTAREAS_ESTADO"},{av:"AV14cTrGestionTareas_Estado",fld:"vCTRGESTIONTAREAS_ESTADO",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTareas_ID",fld:"vCTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"},{av:"AV7cTrGestionTareas_IDTablero",fld:"vCTRGESTIONTAREAS_IDTABLERO",pic:""},{av:"AV8cTrGestionTareas_FechaInicio",fld:"vCTRGESTIONTAREAS_FECHAINICIO",pic:""},{av:"AV9cTrGestionTareas_FechaFin",fld:"vCTRGESTIONTAREAS_FECHAFIN",pic:""},{av:"AV10cTrGestionTareas_FechaCreacion",fld:"vCTRGESTIONTAREAS_FECHACREACION",pic:""},{av:"AV11cTrGestionTareas_FechaModificacion",fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",pic:""},{ctrl:"vCTRGESTIONTAREAS_ESTADO"},{av:"AV14cTrGestionTareas_Estado",fld:"vCTRGESTIONTAREAS_ESTADO",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cTrGestionTareas_ID",fld:"vCTRGESTIONTAREAS_ID",pic:"ZZZZZZZZZZZZ9"},{av:"AV7cTrGestionTareas_IDTablero",fld:"vCTRGESTIONTAREAS_IDTABLERO",pic:""},{av:"AV8cTrGestionTareas_FechaInicio",fld:"vCTRGESTIONTAREAS_FECHAINICIO",pic:""},{av:"AV9cTrGestionTareas_FechaFin",fld:"vCTRGESTIONTAREAS_FECHAFIN",pic:""},{av:"AV10cTrGestionTareas_FechaCreacion",fld:"vCTRGESTIONTAREAS_FECHACREACION",pic:""},{av:"AV11cTrGestionTareas_FechaModificacion",fld:"vCTRGESTIONTAREAS_FECHAMODIFICACION",pic:""},{ctrl:"vCTRGESTIONTAREAS_ESTADO"},{av:"AV14cTrGestionTareas_Estado",fld:"vCTRGESTIONTAREAS_ESTADO",pic:"ZZZ9"}],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_IDTABLERO=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_FECHAINICIO=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_FECHAFIN=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_FECHACREACION=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_FECHAMODIFICACION=[[],[]];this.EvtParms.VALIDV_CTRGESTIONTAREAS_ESTADO=[[],[]];this.setVCMap("AV12pTrGestionTareas_ID","vPTRGESTIONTAREAS_ID",0,"int",13,0);t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(gx0020)})