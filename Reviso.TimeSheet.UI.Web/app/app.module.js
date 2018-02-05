(function () {
    'use strict';

    var myApp = angular.module('app', ['ui.router', 'LocalStorageModule', 'datetime', 'ui.bootstrap']);

    myApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: 'app/home/home.html',
                controller: 'homeController as sub'
            })

            .state('home.list', {
                url: '/home-list',
                templateUrl: 'app/home/home-list.html',
                controller: 'homeController as sub'
            })

            .state('home.paragraph', {
                url: '/home-paragraph',
                template: 'Questo è un esempio di inject di un paragrafo'
            })

            .state('timesheet', {
                url: '/timesheet',
                views: {
                    '': {
                        templateUrl: 'app/timesheet/timesheet.html',
                        controller: 'timeSheetController as sub'
                    }
                }
            })

            .state('project', {
                url: '/project',
                views: {
                    '': {
                        templateUrl: 'app/project/project.html',
                        controller: 'projectController as sub'
                    }
                }
            })

            .state('customer', {
                url: '/customer',
                views: {
                    '': {
                        templateUrl: 'app/customer/customer.html',
                        controller: 'customerController as sub'
                    }
                }
            });

            $urlRouterProvider.otherwise("/timesheet");

            // use the HTML5 History API
            // To make url without hashtag (#)
            //$locationProvider.html5Mode(true);

        });
})();