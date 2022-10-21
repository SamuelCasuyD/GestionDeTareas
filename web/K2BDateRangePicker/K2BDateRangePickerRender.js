
function K2BDateRangePicker(JQuery) {
	this.ValueFrom;
	this.ValueTo;
	this._JQuery = JQuery;
	var uc = this;
	this.pickercontrol = null;
	this.useGxDateForBindings = true;
	
	this.SetValueFrom = function (data) {
		if(data.HasDatePart || data.HasTimePart)
		{
			this.ValueFrom = data;
			this.updatePicker();
		}
	}

	this.GetValueFrom = function () {
		return this.ValueFrom;
	}

	this.SetValueTo = function (data) {
		if(data.HasDatePart || data.HasTimePart)
		{
			this.ValueTo = data;
			this.updatePicker();
		}
	}
	
	this.GetValueTo = function () {
		return this.ValueTo;
	}
	
	this.updatePicker = function (){
		if(this.pickercontrol != null)
		{
			this.pickercontrol.data('daterangepicker').setStartDate(this.ValueFrom.Value);
			this.pickercontrol.data('daterangepicker').setEndDate(this.ValueTo.Value);
		}
	}

	this.show = function () {
		var input = this._JQuery("<input type=\"text\" class=\"form-control Attribute\" value=\"\" size=\"22\" />");
		input.attr("id", this.ControlName);
		this.setHtml(input[0].outerHTML);
		
		switch(gx.dateFormat)
		{
			case "MDY":
				dateFormatString = "MM/DD/YYYY"
				break;
				
			case "DMY":
			default:
				dateFormatString = "DD/MM/YYYY"
				break;
		}
		
		switch(gx.languageCode){
			case "spa":
				dow = ["Dom","Lun","Mar","Mie","Jue","Vie","Sab"];
				mn = ["Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Septiembre","Octubre","Noviembre","Diciembre"];
				break;
				
			case "por":
				dow = ["Dom","Seg","Ter","Qua","Qui","Sex","Sab"];
				mn = ["Janeiro","Fevereiro","Março","Abril","Maio","Junho","Julho","Agosto","Setembro","Outubro","Novembro","Dezembro"];
				break;
				
			case "eng":
			default:
				dow = ["Sun","Mon","Tue","Wed","Thu","Fri","Sat"];
				mn = ["January","February","March","April","May","June","July","August","September","October","November","December"];
				break;
		}
		
		this.pickercontrol = $("#"+this.ControlName).daterangepicker({
			startDate: (uc.ValueFrom != null)?uc.ValueFrom.Value:new Date(),
			endDate: (uc.ValueTo != null)?uc.ValueTo.Value:new Date(),
			autoUpdateInput: false,
			autoApply: true,
			locale: {
				format: dateFormatString,
				daysOfWeek: dow,
				monthNames: mn
			}
		});
		
		var picker = this.pickercontrol.data('daterangepicker');
		if (uc.ValueFrom != null && uc.ValueTo != null){
			$(this.pickercontrol).val(picker.startDate.format(picker.locale.format) + picker.locale.separator + picker.endDate.format(picker.locale.format));
		}
		
		this.pickercontrol.on('apply.daterangepicker', function(ev, picker){
			$(this).val(picker.startDate.format(picker.locale.format) + picker.locale.separator + picker.endDate.format(picker.locale.format));
			uc.ValueFrom = new gx.date.gxdate(picker.startDate.format('YYYY/MM/DD'), "YMD");
			uc.ValueTo = new gx.date.gxdate(picker.endDate.format('YYYY/MM/DD'), "YMD");
			if (typeof(uc.ValueChanged) == 'function')
				uc.ValueChanged();
		});
		
		$("#"+this.ControlName).change(function(){
			var picker = uc.pickercontrol.data('daterangepicker');
			if($(this).val() == ""){
				uc.ValueFrom = new gx.date.gxdate("");
				uc.ValueTo = new gx.date.gxdate("");
				
				picker.setStartDate(moment());
				picker.setEndDate(moment());
				
				if (typeof(uc.ValueChanged) == 'function')
					uc.ValueChanged();
			}else{
				$(this).val(picker.startDate.format(picker.locale.format) + picker.locale.separator + picker.endDate.format(picker.locale.format));
				uc.ValueFrom = new gx.date.gxdate(picker.startDate.format('YYYY/MM/DD'), "YMD");
				uc.ValueTo = new gx.date.gxdate(picker.endDate.format('YYYY/MM/DD'), "YMD");
				if (typeof(uc.ValueChanged) == 'function')
					uc.ValueChanged();
			}
		});
	}
}
