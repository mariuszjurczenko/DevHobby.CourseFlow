﻿using MediatR;

namespace DevHobby.CourseFlow.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
{
}
