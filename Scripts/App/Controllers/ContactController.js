/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Controller, Backbone, $, undefined) {
    Controller.Contact = Controller.Base.extend({

        routes: { "contact": "contact" },

        contact: function () {
            this.slidePage(this.page);
        },

        page: $('[data-page="Contact"]'),

        layouts: function () {
            return [{ view: "UserBar", model: "User"}];
        }
        
    });
} (window.Controller = window.Controller || {}, Backbone, jQuery));