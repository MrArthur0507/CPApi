using CPApi.ViewModel;

namespace CPApi.Service
{
    public interface IBasicCompilerService
    {
        public string Compile(ExerciseViewModel exerciseViewModel);
    }
}
