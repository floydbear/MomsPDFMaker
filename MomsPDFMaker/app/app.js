(function () {
    var pdfApp = angular.module('pdfApp', ['ngRoute']);

    pdfApp.config(['$routeProvider', function ($routeProvider) {
        console.log("in config");
        $routeProvider
            .when('/', {
                templateUrl: '/app/Views/Home.html',
                controller: 'HomeController'
            });
    }]);


 

})();