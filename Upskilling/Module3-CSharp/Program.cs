class Program
{
    static async Task Main()
    {
        Task01_HelloWorld.Run();
        Task02_ValueVsReferenceTypes.Run();
        Task03_PrimaryConstructors.Run();
        Task04_TypeInferenceWithVar.Run();
        Task05_ConditionalGradeCalculation.Run();
        Task06_LoopThroughArray.Run();
        Task07_MethodOverloading.Run();
        Task08_RefOutInParameters.Run();
        Task09_LocalFunctions.Run();
        Task10_OopBasicsWithConstructors.Run();
        Task11_AccessModifiers.Run();
        Task12_AutoPropertiesAndBackingFields.Run();
        Task13_RecordsWithInitProperties.Run();
        Task14_InheritanceAndMethodOverriding.Run();
        Task15_AbstractClassesVsInterfaces.Run();
        Task16_HandleNullReferencesSafely.Run();
        Task17_NullConditionalChainingContactApp.Run();
        Task18_RequiredModifier.Run();
        Task19_ListsAndDictionaries.Run();
        Task20_LinqFilteringAndProjection.Run();
        Task21_PatternMatchingIsAndSwitch.Run();
        Task22_Tuples.Run();
        await Task23_AsyncFileUploadSimulation.Run();
        Task24_JsonSerializeDeserialize.Run();
        Task25_FileStreamAndMemoryStream.Run();
        Task26_RaceConditionsWithMultithreading.Run();
        Task27_DeadlockSimulationAndResolution.Run();
        Task28_LoggingWithSystemDiagnosticsTrace.Run();
        Task29_SanitizeInputPreventXss.Run();
        Task30_CrudViaAdoNet.Run();
    }
}
