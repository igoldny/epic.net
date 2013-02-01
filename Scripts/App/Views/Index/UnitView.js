/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Views, Models, Backbone, $, undefined) {
    Views.Unit = Backbone.View.extend({

        el: $('#Unit'),
        _template: $("#UnitTemplate").html(),

        events:
        {
            'click #btnLearnMore': 'clickLearnMore'
        },

        initialize: function (options) {
            this.model = new Models[options.modelName](options.data);
            this.render();
        },

        render: function () {
            this.$el.html($.tmpl(this._template, this.model.toJSON()));
        },

        clickLearnMore: function (e) {
            Application.Base.navigate("about", { trigger: true });
        }
    });
} (window.Views = window.Views || {}, window.Models = window.Models || {}, Backbone, jQuery));