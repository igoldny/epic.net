(function (Collections, Models, Backbone, undefined) {
    Collections.Article = Backbone.Collection.extend({
        model: Models.Article
    });
} (window.Collections = window.Collections || {}, Models, Backbone));