$(function () {
    // Demoware: No cancel etc.

    $('.in-place-edit').hide();
    $(document.body).on('click', '.in-place-view img', function () {
        var $view = $(this).parent(),
            $edit = $view.parent().find('.in-place-edit');

        $view.hide();
        $edit.show();
        $edit.find('input').focus();
        $('.in-place-view img').hide();
    });

    $(document.body).on('click', '.in-place-edit img', function () {
        var $parent = $(this).parents('.in-place-text', '.in-place-text'),
            postTo = $parent.data('post-to'),
            $input = $parent.find('input'),
            property = $input.attr('name'),
            data;

        data = {
            Id: $input.data('id'),
            Version: $input.data('version')
        };
        data[property] = $input.val();

        $.post(postTo, data)
            .success(function (result) {
                if (result.error === undefined) {
                    history.go(0);
                } else {
                    alert(result.error);
                }
            })
            .error(function () { alert('Error executing command'); });
    });
});
