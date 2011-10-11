var App = Backbone.Router.extend({
    routes: {
        "": 'index'
    },

    initialize: function () {

    },

    index: function () {
        
    }
});

$(function () {
    window.App = new App();
    Backbone.history.start();
});