$(function () {
    var Article,
        Articles,
        ArticleCollection,
        ArticlesView,
        View;

    Article = Backbone.Model.extend({
        initialize: function () {
            console.log('this model has been initialized');
        }
    });
    ArticleCollection = Backbone.Collection.extend({ model: Article });
    ArticlesView = Backbone.View.extend({
        el: $('#articles'),
        render: function (event) {
            var compiledTemplate = _.template($("#article-template").html());
            this.el.html(compiledTemplate(this.model.toJSON()));
            return this; //recommended as this enables calls to be chained.
        }
    });

    Articles = new ArticleCollection();
    Articles.url = 'http://articlesservice/articles';
    Articles.fetch();

    View = new ArticlesView({ model: Articles });
    View.render();
});

