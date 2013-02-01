module("Unit Test");

QUnit.specify("Pavlov", function () {
    describe("Unit", function () {
        var Unit = {},
            UnitTest = new Views.Unit({ modelName: "Unit", data: Unit });

        it("should initialized Unit widget", function () {
            ok(UnitTest, "Unit widget initialized");
        });

        it("should render Unit element", function () {
            assert($(UnitTest.el).length).equals(1);
        });
    });
});