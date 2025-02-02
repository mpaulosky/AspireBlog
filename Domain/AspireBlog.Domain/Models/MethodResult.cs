// =======================================================
// Copyright (c) 2025. All rights reserved.
// File Name :     MethodResult.cs
// Company :       mpaulosky
// Author :        Matthew Paulosky
// Solution Name : AspireBlog
// Project Name :  AspireBlog.Domain
// =======================================================

namespace AspireBlog.Domain.Models;

public class MethodResult
{

	public bool Status { get; }

	public string? ErrorMessage { get; }

	internal MethodResult(bool status)
	{

		Status = status;

	}

	internal MethodResult(bool status, string errorMessage)
	{

		Status = status;

		ErrorMessage = errorMessage;

	}

	public static MethodResult Success()
	{
		return new MethodResult(true);
	}

	public static MethodResult Failure(string errorMessage)
	{
		return new MethodResult(false, errorMessage);
	}

}