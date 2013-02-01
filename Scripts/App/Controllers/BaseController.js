/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (Controller, Backbone, $, undefined) {
    Controller.Base = Backbone.Router.extend({

        $Container: $('#container'),
        $Overlay: $('#Overlay'),
        $Loading: $('#Loading'),

        routes: {},

        initialize: function (options) {

        },

        loadLayoutsWithModels: function (options) {
            var that = this,
                allModels = [],
                existingModels = [];

            // unsubscribe Refresh
            DataSource.unsubscribeRefresh();
            this.viewsList = [];

            // go over all the widgets
            _.each(options.layouts, function (widget) {
                var opts = $.extend(true, {}, options);

                if (widget.model) {
                    allModels.push(widget.model); // save each model
                }

                // save the models that we have
                // to remove them from the future list
                // and the one we have in cache load
                existingModels.push(DataSource.getModel(widget.model, widget.expires, function (modelData) {
                    opts.modelName = widget.model;
                    opts.data = modelData;

                    if (widget.dialog) {
                        DialogManager.add(new Views[widget.dialog](opts));
                    } else {
                        that.viewsList.push(widget.page ? new Views[widget.page][widget.view](opts) : new Views[widget.view](opts));
                    }

                }));
            });

            // get the missing models from the server
            // and after we get the data load the widgets with the data
            DataSource.getMissingModels(allModels, existingModels);
            return this;
        },

        slidePage: function ($page) {
            var that = this,
                $visiblePage = $('.page:visible');

            if ($visiblePage.length > 0) {
                $visiblePage.fadeOut("fast", function () {
                    $page.fadeIn("fast");
                });
            } else {
                $page.show();
            }

            return this;
        }
    });
} (window.Controller = window.Controller || {}, Backbone, jQuery));