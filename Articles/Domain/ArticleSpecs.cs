using System;
using Articles.Events;
using Infrastructure;
using Machine.Specifications;

namespace Articles.Domain
{
    [Subject(typeof (Article))]
    public class When_renaming_an_article
    {
        Establish context = () =>
        {
            id = Guid.NewGuid();
            article = new Event[]
                          {
                              new ArticleInserted(id, "Before")
                          }.RestoreAggregate<Article>();
        };

        Because of = () => article.Rename("After");

        It should_an_article_renamed_event_be_emitted =
            () => article.ShouldEmitOneEventOfType<ArticleRenamed>();

        It should_emit_an_article_renamed_event_with_new_name =
            () => article.EmittedEvent<ArticleRenamed>().Name.ShouldEqual("After");

        static Guid id;
        static Article article;
    }

    [Subject(typeof(Article))]
    public class When_renaming_an_article_to_empty_name
    {
        Establish context = () =>
        {
            id = Guid.NewGuid();
            article = new Event[]
                          {
                              new ArticleInserted(id, "Before")
                          }.RestoreAggregate<Article>();
        };

        Because of = () => exception = Catch.Exception(() => article.Rename(""));

        It should_not_be_possible = () => exception.ShouldNotBeNull();

        static Guid id;
        static Article article;
        static Exception exception;
    }
}