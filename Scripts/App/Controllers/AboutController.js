/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Controller, Backbone, $, undefined) {
    Controller.About = Controller.Base.extend({
        
        routes: { "about": "about" },

        about: function () {
            this.slidePage(this.page);
        },

        page: $('[data-page="About"]'),

        layouts: function () {
            return [{ view: "UserBar", model: "User"}];
        }

    });
} (window.Controller = window.Controller || {}, Backbone, jQuery));