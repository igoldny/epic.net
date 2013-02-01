/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Application, Backbone, $, undefined) {
    Application.Base = new Controller.Base();
    Application.Index = new Controller.Index();
    Application.About = new Controller.About();
    Application.Contact = new Controller.Contact();

    Backbone.history.start();
} (window.Application = window.Application || {}, Backbone, jQuery));