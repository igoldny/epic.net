/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Controller, Backbone, $, undefined) {
    Controller.Index = Controller.Base.extend({

        routes: { "": "index" },

        index: function () {
            this.loadLayoutsWithModels({ layouts: this.layouts() })
                .slidePage(this.page);
        },

        page: $('[data-page="Index"]'),

        layouts: function () {
            return [{ view: "Unit", model: "Unit", expires: 3000 },
                    { view: "Article", model: "Article", expires: 3000 }];
        }

    });
} (window.Controller = window.Controller || {}, Backbone, jQuery));