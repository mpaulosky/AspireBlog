// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     ObjectIdGuard.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.GuardClauses;

public static class GuardClauseExtensions
{

	public static ObjectId EmptyObjectId(
			this IGuardClause guardClause,
			ObjectId input,
			string parameterName,
			string? message = null,
			Func<Exception>? exceptionCreator = null)
	{

		if (input == ObjectId.Empty)
		{

			var exception = exceptionCreator?.Invoke();

			throw exception ?? new ArgumentException(message ?? $"Required input {parameterName} was empty.", parameterName);

		}

		return input;

	}

}