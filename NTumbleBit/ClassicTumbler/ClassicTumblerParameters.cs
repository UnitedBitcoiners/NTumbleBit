﻿using NBitcoin;
using NTumbleBit.PuzzlePromise;
using NTumbleBit.PuzzleSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTumbleBit.ClassicTumbler
{
	public class ClassicTumblerParameters
	{
		public ClassicTumblerParameters()
		{

		}
		public ClassicTumblerParameters(RsaPubKey rsaKey)
		{
			if(rsaKey == null)
				throw new ArgumentNullException("rsaKey");
			ServerKey = rsaKey;

			var solver = new SolverParameters();
			FakePuzzleCount = solver.FakePuzzleCount;
			RealPuzzleCount = solver.RealPuzzleCount;

			var promise = new PromiseParameters();
			FakeTransactionCount = promise.FakeTransactionCount;
			RealTransactionCount = promise.RealTransactionCount;
			FakeFormat = promise.FakeFormat;

			Denomination = Money.Coins(1.0m);
			Fee = Money.Coins(0.01m);

			// 1 day cycle
			CycleParameters = new CycleParameters()
			{
				Start = 440000,
				CashoutDuration = 38,
				AliceEscrowDuration = 19,
				TumblerEscrowDuration = 19,
				ConfirmationDuration = 6,
				PaymentDuration = 38,
				TumblerCashoutDuration = 18				
			};
		}

		public CycleParameters CycleParameters
		{
			get; set;
		}

		public RsaPubKey ServerKey
		{
			get; set;
		}

		public Money Denomination
		{
			get; set;
		}

		public Money Fee
		{
			get; set;
		}

		public int FakePuzzleCount
		{
			get; set;
		}
		public int RealPuzzleCount
		{
			get; set;
		}
		public int FakeTransactionCount
		{
			get; set;
		}
		public int RealTransactionCount
		{
			get; set;
		}
		public uint256 FakeFormat
		{
			get; set;
		}		

		public bool Check(PromiseParameters promiseParams)
		{
			return promiseParams.FakeTransactionCount == FakeTransactionCount &&
				promiseParams.RealTransactionCount == RealTransactionCount;
		}

		public bool Check(SolverParameters solverParams)
		{
			return solverParams.FakePuzzleCount == FakePuzzleCount &&
				solverParams.RealPuzzleCount == RealPuzzleCount;
		}
	}
}
