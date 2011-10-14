var OrderView = Backbone.View.extend({
        tagName: 'li',
        template: '#orderTemplate',
        
        initialize: function() {
            _.bindAll(this, 'render');
            this.template = _.template($(this.template).html());
        },
        render: function() {
            $(this.el).html(this.template(this.model.toJSON()));
            return this;
        }
    });
