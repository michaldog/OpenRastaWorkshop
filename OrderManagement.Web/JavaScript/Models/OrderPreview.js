var OrderPreview = Backbone.Model.extend({
    getTitle: function () {
        return this.get('reference') || "new order";
    }
});