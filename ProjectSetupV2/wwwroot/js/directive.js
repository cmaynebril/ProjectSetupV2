(function () {
    'use strict';

    angular
        .module('app')
        .directive('directive', function () {
            return {
                restrict: 'A', // only HTML attributes
                scope: true, // make sure the $scope is different each time you use it
                controller: function () {

                }
            };
        })

        .directive('checkLinked', function () {
            return {
                restrict: 'A',
                scope: true,
                controller: function ($attrs, $scope, $element) {

                    $element.click(function () {
                        console.log("clicking me");
                        if ($(this).prop("checked"))
                            $scope.$parent.checkSelected($attrs.checkLinked, $attrs.checkMapping);
                        else
                            $scope.$parent.unCheckSelected($attrs.checkLinked, $attrs.checkMapping);
                     });

                }
            };
         });


})();