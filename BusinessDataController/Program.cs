﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* Premiers éléments à contrôler
 * 
 * 
Document/Description									Métier			Champ Nom (position 3)
Document/Creation										Métier			Champ Date (position 4)
Document/Attachment 				filename			Métier			Champ Nom (position 1)
/ArchiveTransfer/Archive/Name															Métier			#TransferName								1.0
/ArchiveTransfer/Contains/Name															Métier			#TransferName								0.2
/ArchiveTransfer/Comment																Métier			#Comment
/ArchiveTransfer/Archive/ContentDescription/OriginatingAgency/BusinessType				Métier			#OriginatingAgency_BusinessType				1.0	
/ArchiveTransfer/Archive/ContentDescription/OriginatingAgency/Identification			Métier			#OriginatingAgency_Identification			1.0	
/ArchiveTransfer/Archive/ContentDescription/OriginatingAgency/Description				Métier			#OriginatingAgency_Description				1.0	
/ArchiveTransfer/Archive/ContentDescription/OriginatingAgency/LegalClassification		Métier			#OriginatingAgency_LegalClassification		1.0	
/ArchiveTransfer/Archive/ContentDescription/OriginatingAgency/Name						Métier			#OriginatingAgency_Name						1.0	
/ArchiveTransfer/Contains/ContentDescription/OriginatingAgency/BusinessType				Métier			#OriginatingAgency_BusinessType				0.2	
/ArchiveTransfer/Contains/ContentDescription/OriginatingAgency/Identification			Métier			#OriginatingAgency_Identification			0.2	
/ArchiveTransfer/Contains/ContentDescription/OriginatingAgency/Description				Métier			#OriginatingAgency_Description				0.2
/ArchiveTransfer/Contains/ContentDescription/OriginatingAgency/LegalClassification		Métier			#OriginatingAgency_LegalClassification		0.2
/ArchiveTransfer/Contains/ContentDescription/OriginatingAgency/Name						Métier			#OriginatingAgency_Name						0.2
/ArchiveTransfer/Archive/ContentDescription/CustodialHistory							Métier			#CustodialHistory							1.0
/ArchiveTransfer/Contains/ContentDescription/CustodialHistory							Métier			#CustodialHistory							0.2
/ArchiveTransfer/Archive/ContentDescription/Keyword/KeywordContent						Métier			#KeywordContent[#x]							1.0
/ArchiveTransfer/Contains/ContentDescription/ContentDescriptive/KeywordContent			Métier			#KeywordContent[#x]							0.2
/ArchiveTransfer/Archive/ArchiveObject/TransferringAgencyObjectIdentifier				Métier			TODO										1.0
/ArchiveTransfer/Contains/Contains/TransferringAgencyObjectIdentifier					Métier			TODO										0.2
ArchiveObject/Name																		Métier			#ContainsName[TagPath]						1.0
Contains/Contains/Name																	Métier			#ContainsName[TagPath]						0.2
ArchiveObject/ContentDescription/Keyword/KeywordContent									Métier			#KeywordContent_TagPath[#x]					1.0
Contains/ContentDescription/ContentDescriptive/KeywordContent							Métier			#KeywordContent_TagPath[#x]					0.2

 * 
 * */

namespace BusinessDataController {
    class Program {
        static void Main(string[] args) {
        }
    }
}