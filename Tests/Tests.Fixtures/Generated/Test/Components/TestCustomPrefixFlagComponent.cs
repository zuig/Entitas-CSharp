public partial class TestContext {

    public TestEntity customPrefixFlagEntity { get { return GetGroup(TestMatcher.CustomPrefixFlag).GetSingleEntity(); } }

    public bool myCustomPrefixFlag {
        get { return customPrefixFlagEntity != null; }
        set {
            var entity = customPrefixFlagEntity;
            if(value != (entity != null)) {
                if(value) {
                    CreateEntity().myCustomPrefixFlag = true;
                } else {
                    DestroyEntity(entity);
                }
            }
        }
    }
}

public partial class TestEntity {

    static readonly CustomPrefixFlagComponent customPrefixFlagComponent = new CustomPrefixFlagComponent();

    public bool myCustomPrefixFlag {
        get { return HasComponent(TestComponentsLookup.CustomPrefixFlag); }
        set {
            if(value != myCustomPrefixFlag) {
                if(value) {
                    AddComponent(TestComponentsLookup.CustomPrefixFlag, customPrefixFlagComponent);
                } else {
                    RemoveComponent(TestComponentsLookup.CustomPrefixFlag);
                }
            }
        }
    }
}

public sealed partial class TestMatcher {

    static Entitas.IMatcher<TestEntity> _matcherCustomPrefixFlag;

    public static Entitas.IMatcher<TestEntity> CustomPrefixFlag {
        get {
            if(_matcherCustomPrefixFlag == null) {
                var matcher = (Entitas.Matcher<TestEntity>)Entitas.Matcher<TestEntity>.AllOf(TestComponentsLookup.CustomPrefixFlag);
                matcher.componentNames = TestComponentsLookup.componentNames;
                _matcherCustomPrefixFlag = matcher;
            }

            return _matcherCustomPrefixFlag;
        }
    }
}
