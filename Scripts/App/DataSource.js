/// <reference path="../jQuery/jquery-vsdoc.js"/>

(function (DataSource, $, undefined) {
    var _SEPARATOR = ",",
        _DEFAULT_DATA_HANDLER = Configuration.DEFAULT_DATA_HANDLER,
        _DEFAULT_EXPIRATION = 1,
        _REFRESH_INTERVAL_SECONDS = 60,
        _RUN_ONCE = [],
        _IS_RUN_ONCE_NEEDED = true,
        waingList = [],
        waingToRefreshList = [],
        _updatesTimer,
        isFirstRequestForModularData = true;

    //#region Private methods
    function getJson(handler, data, fn) {
        $.ajax({
            url: handler,
            data: data,
            cache: false,
            success: function (data) {
                if (fn) {
                    fn(data);
                }

                if (_IS_RUN_ONCE_NEEDED) {
                    DataSource.execCallbacksOnceDataLoaded();
                    _IS_RUN_ONCE_NEEDED = false;
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                if (jqXHR.status !== 0) {
                    throw errorThrown;
                }
            }
        });
    }

    function getModularData(neededModels, callback) {
        // pass the models that we need to the request
        // and call a callback with the returned data
        getJson(_DEFAULT_DATA_HANDLER, { Models: _.uniq(neededModels).join(_SEPARATOR) }, callback);
    }

    function startRefreshing() {
        // If there's a timeout already, clear it to avoid overlapping.
        clearTimeout(_updatesTimer);
        _refresh();
    }

    function _refresh() {
        var modelsToRefresh = [];
        _.each(waingToRefreshList, function (item) {
            modelsToRefresh.push(item.model);
        });

        if (modelsToRefresh.length > 0) {
            getModularData(modelsToRefresh, function (data) {
                _.each(waingToRefreshList, function (item) {
                    item.callback(data[item.model]);
                });
            });
        }

        // Set the timeout for the next run.
        _updatesTimer = setTimeout(_refresh, _REFRESH_INTERVAL_SECONDS * 1000);
    }
    //#endregion

    //#region Public methods
    DataSource.getCustomRequest = function (handler, data, callback) {
        getJson(handler, data, callback);
    };

    DataSource.getModel = function (model, expires, callback) {
        // if its non model widget
        // load it without data
        if (!model) {
            callback();
            return;
        }

        // check if we have this model in local storage
        var modelData = amplify.store(model);
        // if we have call back with the data
        // and return the model name
        if (modelData) {
            callback(modelData);
            return model;
        }

        // add to a waing list the model and the callback that we dont have yet
        waingList.push({
            model: model,
            callback: callback,
            expires: expires ? expires : _DEFAULT_EXPIRATION // set expiration of the data, if not set use default 
        });
    };

    DataSource.getMissingModels = function (allModels, existingModels) {
        // remove from allModels existingModels, to get the list with the needed models
        var neededModels = [];
        _.each(allModels, function (model) {
            var contains = false;
            _.each(existingModels, function (existingmodel) {
                if (model == existingmodel) {
                    contains = true;
                }
            });

            if (!contains) {
                neededModels.push(model);
            }
        });

        // get need models
        // if there is needed models
        // and when call back with data load
        // save the data at local storage
        // load from the waiting list widgets
        if (neededModels.length > 0) {
            getModularData(neededModels, function (data) {
                _.each(waingList, function (waingItem) {
                    if (waingItem.expires && waingItem.expires > 1) {
                        amplify.store(waingItem.model, data[waingItem.model], { expires: waingItem.expires });
                    }

                    waingItem.callback(data[waingItem.model]);
                });

                waingList = [];
            });
        }

        startRefreshing(); // start refreshing if there is subscriptions
    };

    DataSource.subscribeRefreshModel = function (model, callback) {
        waingToRefreshList.push({
            model: model,
            callback: callback
        });
    };

    DataSource.unsubscribeRefresh = function () {
        waingToRefreshList = [];
        clearTimeout(_updatesTimer);
    };

    DataSource.startRefresh = function () {
        _refresh();
    };

    DataSource.cleanModel = function (model) {
        amplify.store(model, null);
    };

    DataSource.execCallbacksOnceDataLoaded = function () {
        if (_RUN_ONCE.length > 0) {
            for (var i = 0; i < _RUN_ONCE.length; i++) {
                var cb = _RUN_ONCE[i];

                if (cb) {
                    cb();
                }
            }
        }
    };

    DataSource.runOnceDataLoaded = function (callback) {
        if (_IS_RUN_ONCE_NEEDED) {
            _RUN_ONCE.push(callback);
            return;
        }

        callback();
    };
    //#endregion
} (window.DataSource = window.DataSource || {}, jQuery));