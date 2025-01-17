// =======================================
// Copyright (c) 2025. All rights reserved.
// File Name :     MethodResult.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// ========================================================

namespace AspireBlog.Domain.Models;

public record struct MethodResult(bool Status, string? ErrorMessage = null)
{

	public static MethodResult Success()
	{

		return new MethodResult(true);

	}

	public static MethodResult Failure(string errorMessage)
	{

		return new MethodResult(false, errorMessage);

	}

	public static MethodResult Failure(string? message, params object?[] args)
	{
		var formattedMessage = message is not null ? string.Format(message, args) : null;
		return new MethodResult(false, formattedMessage);
	}

}