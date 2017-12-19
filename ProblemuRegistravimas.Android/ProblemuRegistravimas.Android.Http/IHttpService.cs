using System.Collections.Generic;
using ProblemuRegistravimas.AndroidProject.Models;

namespace ProblemuRegistravimas.AndroidProject.Http
{
    public interface IHttpService
    {
        bool LoginUser(Login login);
        List<string> GetUsers();
        List<string> GetLocationAutocompleteList(string query);
        List<Problem> GetProblems(string status);
        Problem GetProblem(int id);
        bool AssignProblem(int problemId);
        bool CloseProblem(int problemId);
    }
}