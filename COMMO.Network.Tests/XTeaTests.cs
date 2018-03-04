using COMMO.Network.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace COMMO.Network.Tests {

	[TestClass]
	public sealed class XTeaTests {
		// private readonly uint[] _referenceEncryptionKey = new uint[] { 3442030272, 2364789040, 1503299581, 3670909886 };
		private readonly byte[] _referenceEncryptionKey = null;
		private readonly byte[] _referenceMessageToEncrypt = new byte[] { 123, 0, 20, 20, 0, 48, 10, 66, 101, 109, 32, 118, 105, 110, 100, 111 };
		private readonly byte[] _referenceEncryptedMessage = new byte[] { 163, 35, 242, 102, 150, 173, 252, 174, 83, 54, 209, 248, 35, 145, 205, 229 };

		[TestMethod]
		public void XTeaEncryption_Validation() {
			var encryptedMessage = XTea.Encrypt(_referenceMessageToEncrypt, _referenceEncryptionKey);
			Assert.IsTrue(encryptedMessage.SequenceEqual(_referenceEncryptedMessage));
		}

		[TestMethod]
		public void XTeaDecryption_Validation() {
			var decryptedMsg = XTea.Decrypt(_referenceEncryptedMessage, _referenceEncryptionKey);
			Assert.IsTrue(decryptedMsg.SequenceEqual(_referenceEncryptedMessage));
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void XTeaEncryption_Validation_EmptyMessage() {
			var encryptedMessage = XTea.Encrypt(new byte[] {}, _referenceEncryptionKey);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void XTeaEncryption_Validation_WrongBlockSize() {
			var encryptedMessage = XTea.Encrypt(new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, _referenceEncryptionKey);
		}

		[TestMethod]
		[ExpectedException(typeof(System.Exception))]
		public void XTeaEncryption_Validation_WrongKeySize() {
			var encryptedMessage = XTea.Encrypt(_referenceEncryptedMessage, new byte[] { 0, 0, 0 });
		}
	}
}