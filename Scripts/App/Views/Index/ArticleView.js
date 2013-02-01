/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Views, Models, Backbone, $, undefined) {
    Views.Article = Backbone.View.extend({

        el: $('#Article'),
        _template: $("#ArticleTemplate").html(),

        events:
        {
            'click .btnViewDetails': 'clickViewDetails'
        },

        initialize: function (options) {
            this.collection = new Collections[options.modelName](options.data);
            this.render();
        },

        render: function () {
            this.$el.html($.tmpl(this._template, this.collection.toJSON()));
        },

        clickViewDetails: function (e) {
            Application.Base.navigate("about", { trigger: true });
            return false;
        }
    });
} (window.Views = window.Views || {}, window.Models = window.Models || {}, Backbone, jQuery));