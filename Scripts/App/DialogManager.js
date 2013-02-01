/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (DialogManager, $, undefined) {
    var dialogs = [],
        isDialogOpen = false;

    //#region Public methods
    DialogManager.add = function (dialog) {
        dialogs.push(dialog);

        if (!isDialogOpen) {
            this.next();
        }
    };

    DialogManager.clear = function () {
        isDialogOpen = false;
        dialogs = [];
    };

    DialogManager.next = function () {
        var dialog = dialogs.shift();

        if (!dialog) {
            isDialogOpen = false;
            return;
        }

        isDialogOpen = true;
        dialog.enabled(function (enabled) {
            if (enabled) {
                dialog.load();
                return dialog;
            }
            else {
                isDialogOpen = false;
                DialogManager.next();
            }
        });
    };
    //#endregion
} (window.DialogManager = window.DialogManager || {}, jQuery));