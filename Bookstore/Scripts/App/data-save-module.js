var dataSaveModule = angular.module('dataSaveModule', []);

dataSaveModule.factory('dataSaveService', function () {
    var savedData = {};

    set = function (data) {
        savedData = data;
        console.log(savedData);
    };

    get = function () {
        return savedData;
    };

    return {
        set: set,
        get: get
    }
});