 namespace Terrasoft.Configuration.Translation
{
	using System;
	using System.Collections.Generic;

	#region Interface: IApplyTranslationsParametersRepository 

	public interface IApplyTranslationsParametersRepository : IEntityRepository<ApplyTranslationParameters>
	{
		/// <summary>
		/// Update stage of apply translations.
		/// </summary>
		/// <param name="applySessionId"></param>
		/// <param name="newApplyTranslationsStage"></param>
		void UpdateApplyStage(Guid applySessionId, ApplyTranslationsStagesEnum newApplyTranslationsStage);

		/// <summary>
		/// Delete parameters for apply session
		/// </summary>
		/// <param name="applySessionId"></param>
		void Delete(Guid applySessionId);

		/// <summary>
		/// Gets cancel flag.
		/// </summary>
		/// <param name="applySessionId"></param>
		/// <returns>Cancel flag.</returns>
		bool GetIsApplySessionCanceled(Guid applySessionId);

		/// <summary>
		/// Update flag canceled of apply session
		/// </summary>
		/// <param name="applySessionId">Import session Id.</param>
		void CancelApplySession(Guid applySessionId);

		/// <summary>
		/// Update process identifier of apply session.
		/// </summary>
		/// <param name="applySessionId">Apply session identifier.</param>
		/// <param name="processId">Apply translations process instance identifier.</param>
		void UpdateApplyProcessId(Guid applySessionId, Guid processId);

		/// <summary>
		/// Gets apply parameters with process incomplete.
		/// </summary>
		/// <returns>Dictionary with key is process instance identifier and value is apply parameters.</returns>
		Dictionary<Guid, ApplyTranslationParameters> GetWithProcessIncomplete();

	}

	#endregion

}




