﻿using System;
using XamarinFormsStarterKit.UserInterfaceBuilder.Helpers;

namespace XAMLExtensions
{
	public class RunTests
	{
		public RunTests()
		{

			var ZipCode = BogusGenerator.ZipCode();
			Console.WriteLine("ZipCode:" + ZipCode);
			var City = BogusGenerator.City();
			Console.WriteLine("City:" + City);
			var StreetAddress = BogusGenerator.StreetAddress(false);
			Console.WriteLine("StreetAddress:" + StreetAddress);
			var CityPrefix = BogusGenerator.CityPrefix();
			Console.WriteLine("CityPrefix:" + CityPrefix);
			var CitySuffix = BogusGenerator.CitySuffix();
			Console.WriteLine("CitySuffix:" + CitySuffix);
			var StreetName = BogusGenerator.StreetName();
			Console.WriteLine("StreetName:" + StreetName);
			var BuildingNumber = BogusGenerator.BuildingNumber();
			Console.WriteLine("BuildingNumber:" + BuildingNumber);
			var StreetSuffix = BogusGenerator.StreetSuffix();
			Console.WriteLine("StreetSuffix:" + StreetSuffix);
			var SecondaryAddress = BogusGenerator.SecondaryAddress();
			Console.WriteLine("SecondaryAddress:" + SecondaryAddress);
			var County = BogusGenerator.County();
			Console.WriteLine("County:" + County);
			var Country = BogusGenerator.Country();
			Console.WriteLine("Country:" + Country);
			var FullAddress = BogusGenerator.FullAddress();
			Console.WriteLine("FullAddress:" + FullAddress);
			var CountryCode = BogusGenerator.CountryCode("Alpha2");
			Console.WriteLine("CountryCode:" + CountryCode);
			var State = BogusGenerator.State();
			Console.WriteLine("State:" + State);
			var StateAbbr = BogusGenerator.StateAbbr();
			Console.WriteLine("StateAbbr:" + StateAbbr);
			var Latitude = BogusGenerator.Latitude(9, 9);
			Console.WriteLine("Latitude:" + Latitude);
			var Longitude = BogusGenerator.Longitude(5, 7);
			Console.WriteLine("Longitude:" + Longitude);
			var Direction = BogusGenerator.Direction(false);
			Console.WriteLine("Direction:" + Direction);
			var CardinalDirection = BogusGenerator.CardinalDirection(false);
			Console.WriteLine("CardinalDirection:" + CardinalDirection);
			var OrdinalDirection = BogusGenerator.OrdinalDirection(false);
			Console.WriteLine("OrdinalDirection:" + OrdinalDirection);
			var Department = BogusGenerator.Department(3, false);
			Console.WriteLine("Department:" + Department);
			var Price = BogusGenerator.Price(1, 1, 0002, "$");
			Console.WriteLine("Price:" + Price);
			var Categories = BogusGenerator.Categories(3);
			Console.WriteLine("Categories:" + Categories);
			var ProductName = BogusGenerator.ProductName();
			Console.WriteLine("ProductName:" + ProductName);
			var Color = BogusGenerator.Color();
			Console.WriteLine("Color:" + Color);
			var Product = BogusGenerator.Product();
			Console.WriteLine("Product:" + Product);
			var ProductAdjective = BogusGenerator.ProductAdjective();
			Console.WriteLine("ProductAdjective:" + ProductAdjective);
			var ProductMaterial = BogusGenerator.ProductMaterial();
			Console.WriteLine("ProductMaterial:" + ProductMaterial);
			var CompanySuffix = BogusGenerator.CompanySuffix();
			Console.WriteLine("CompanySuffix:" + CompanySuffix);
			var CompanyName = BogusGenerator.CompanyName(2);
			Console.WriteLine("CompanyName:" + CompanyName);
			CompanyName = BogusGenerator.CompanyName("{{name.lastName}} {{company.companySuffix}}");
			Console.WriteLine("CompanyName:" + CompanyName);
			var CatchPhrase = BogusGenerator.CatchPhrase();
			Console.WriteLine("CatchPhrase:" + CatchPhrase);
			var Bs = BogusGenerator.Bs();
			Console.WriteLine("Bs:" + Bs);
			var Column = BogusGenerator.Column();
			Console.WriteLine("Column:" + Column);
			var Type = BogusGenerator.Type();
			Console.WriteLine("Type:" + Type);
			var Collation = BogusGenerator.Collation();
			Console.WriteLine("Collation:" + Collation);
			var Engine = BogusGenerator.Engine();
			Console.WriteLine("Engine:" + Engine);
			var Past = BogusGenerator.Past(1, DateTime.Now);
			Console.WriteLine("Past:" + Past);
			var Soon = BogusGenerator.Soon(1);
			Console.WriteLine("Soon:" + Soon);
			var Future = BogusGenerator.Future(1, DateTime.Now);
			Console.WriteLine("Future:" + Future);
			var Between = BogusGenerator.Between(DateTime.Now.AddYears(-2), DateTime.Now);
			Console.WriteLine("Between:" + Between);
			var Recent = BogusGenerator.Recent(1);
			Console.WriteLine("Recent:" + Recent);
			var Timespan = BogusGenerator.Timespan(TimeSpan.FromSeconds(10));
			Console.WriteLine("Timespan:" + Timespan);
			var Month = BogusGenerator.Month(false, false);
			Console.WriteLine("Month:" + Month);
			var Weekday = BogusGenerator.Weekday(false, false);
			Console.WriteLine("Weekday:" + Weekday);
			var Account = BogusGenerator.Account(8);
			Console.WriteLine("Account:" + Account);
			var AccountName = BogusGenerator.AccountName();
			Console.WriteLine("AccountName:" + AccountName);
			var Amount = BogusGenerator.Amount(01, 00, 02);
			Console.WriteLine("Amount:" + Amount);
			var TransactionType = BogusGenerator.TransactionType();
			Console.WriteLine("TransactionType:" + TransactionType);
			var Currency = BogusGenerator.Currency(false);
			Console.WriteLine("Currency:" + Currency);
			var CreditCardNumber = BogusGenerator.CreditCardNumber();
			Console.WriteLine("CreditCardNumber:" + CreditCardNumber);
			var CreditCardCvv = BogusGenerator.CreditCardCvv();
			Console.WriteLine("CreditCardCvv:" + CreditCardCvv);
			var BitcoinAddress = BogusGenerator.BitcoinAddress();
			Console.WriteLine("BitcoinAddress:" + BitcoinAddress);
			var EthereumAddress = BogusGenerator.EthereumAddress();
			Console.WriteLine("EthereumAddress:" + EthereumAddress);
			var RoutingNumber = BogusGenerator.RoutingNumber();
			Console.WriteLine("RoutingNumber:" + RoutingNumber);
			var Bic = BogusGenerator.Bic();
			Console.WriteLine("Bic:" + Bic);
			var Iban = BogusGenerator.Iban(false);
			Console.WriteLine("Iban:" + Iban);
			var Abbreviation = BogusGenerator.Abbreviation();
			Console.WriteLine("Abbreviation:" + Abbreviation);
			var Adjective = BogusGenerator.Adjective();
			Console.WriteLine("Adjective:" + Adjective);
			var Noun = BogusGenerator.Noun();
			Console.WriteLine("Noun:" + Noun);
			var Verb = BogusGenerator.Verb();
			Console.WriteLine("Verb:" + Verb);
			var IngVerb = BogusGenerator.IngVerb();
			Console.WriteLine("IngVerb:" + IngVerb);
			var Phrase = BogusGenerator.Phrase();
			Console.WriteLine("Phrase:" + Phrase);
			var Image = BogusGenerator.Image(64, 80, false, false);
			Console.WriteLine("Image:" + Image);
			var Abstract = BogusGenerator.Abstract(640, 480, false, false);
			Console.WriteLine("Abstract:" + Abstract);
			var Animals = BogusGenerator.Animals(640, 480, false, false);
			Console.WriteLine("Animals:" + Animals);
			var Business = BogusGenerator.Business(640, 480, false, false);
			Console.WriteLine("Business:" + Business);
			var Cats = BogusGenerator.Cats(640, 480, false, false);
			Console.WriteLine("Cats:" + Cats);
			  City = BogusGenerator.City(640, 480, false, false);
			Console.WriteLine("City:" + City);
			var Food = BogusGenerator.Food(640, 480, false, false);
			Console.WriteLine("Food:" + Food);
			var Nightlife = BogusGenerator.Nightlife(640, 480, false, false);
			Console.WriteLine("Nightlife:" + Nightlife);
			var Fashion = BogusGenerator.Fashion(640, 480, false, false);
			Console.WriteLine("Fashion:" + Fashion);
			var People = BogusGenerator.People(640, 480, false, false);
			Console.WriteLine("People:" + People);
			var Nature = BogusGenerator.Nature(640, 480, false, false);
			Console.WriteLine("Nature:" + Nature);
			var Sports = BogusGenerator.Sports(640, 480, false, false);
			Console.WriteLine("Sports:" + Sports);
			var Technics = BogusGenerator.Technics(640, 480, false, false);
			Console.WriteLine("Technics:" + Technics);
			var Transport = BogusGenerator.Transport(640, 480, false, false);
			Console.WriteLine("Transport:" + Transport);
			var DataUri = BogusGenerator.DataUri(640, 480);
			Console.WriteLine("DataUri:" + DataUri);
			var Avatar = BogusGenerator.Avatar();
			Console.WriteLine("Avatar:" + Avatar);
			var Email = BogusGenerator.Email("arun", "balakrish", "yahoo");
			Console.WriteLine("Email:" + Email);
			var ExampleEmail = BogusGenerator.ExampleEmail("arun", "balakrish");
			Console.WriteLine("ExampleEmail:" + ExampleEmail);
			var UserName = BogusGenerator.UserName("arun", "balakrish");
			Console.WriteLine("UserName:" + UserName);
			var DomainName = BogusGenerator.DomainName();
			Console.WriteLine("DomainName:" + DomainName);
			var DomainWord = BogusGenerator.DomainWord();
			Console.WriteLine("DomainWord:" + DomainWord);
			var DomainSuffix = BogusGenerator.DomainSuffix();
			Console.WriteLine("DomainSuffix:" + DomainSuffix);
			var Ip = BogusGenerator.Ip();
			Console.WriteLine("Ip:" + Ip);
			var Ipv6 = BogusGenerator.Ipv6();
			Console.WriteLine("Ipv6:" + Ipv6);
			var UserAgent = BogusGenerator.UserAgent();
			Console.WriteLine("UserAgent:" + UserAgent);
			var Mac = BogusGenerator.Mac(":");
			Console.WriteLine("Mac:" + Mac);
			var Password = BogusGenerator.Password(10, false, "\\w", "");
			Console.WriteLine("Password:" + Password);
			var Protocol = BogusGenerator.Protocol();
			Console.WriteLine("Protocol:" + Protocol);
			var Url = BogusGenerator.Url();
			Console.WriteLine("Url:" + Url);
			var UrlWithPath = BogusGenerator.UrlWithPath("tcp", "kumar");
			Console.WriteLine("UrlWithPath:" + UrlWithPath);
			var Word = BogusGenerator.Word();
			Console.WriteLine("Word:" + Word);
			var Words = BogusGenerator.Words(3);
			Console.WriteLine("Words:" + Words);
			var Letter = BogusGenerator.Letter(1);
			Console.WriteLine("Letter:" + Letter);
			var Sentence = BogusGenerator.Sentence(8, 8);
			Console.WriteLine("Sentence:" + Sentence);
			var Sentences = BogusGenerator.Sentences(5, ":");
			Console.WriteLine("Sentences:" + Sentences);
			var Paragraph = BogusGenerator.Paragraph(3);
			Console.WriteLine("Paragraph:" + Paragraph);
			var Paragraphs = BogusGenerator.Paragraphs(3, "_");
			Console.WriteLine("Paragraphs:" + Paragraphs);
			Paragraphs = BogusGenerator.Paragraphs(3, "_");
			Console.WriteLine("Paragraphs:" + Paragraphs);
			var Text = BogusGenerator.Text();
			Console.WriteLine("Text:" + Text);
			var Lines = BogusGenerator.Lines(3, "_");
			Console.WriteLine("Lines:" + Lines);
			var Slug = BogusGenerator.Slug(3);
			Console.WriteLine("Slug:" + Slug);
			var FirstName = BogusGenerator.FirstName("Male");
			Console.WriteLine("FirstName:" + FirstName);
			var LastName = BogusGenerator.LastName("Male");
			Console.WriteLine("LastName:" + LastName);
			var FullName = BogusGenerator.FullName("Male");
			Console.WriteLine("FullName:" + FullName);
			var Prefix = BogusGenerator.Prefix("Male");
			Console.WriteLine("Prefix:" + Prefix);
			var Suffix = BogusGenerator.Suffix();
			Console.WriteLine("Suffix:" + Suffix);
			var FindName = BogusGenerator.FindName("", "", false, false, "Male");
			Console.WriteLine("FindName:" + FindName);
			var JobTitle = BogusGenerator.JobTitle();
			Console.WriteLine("JobTitle:" + JobTitle);
			var JobDescriptor = BogusGenerator.JobDescriptor();
			Console.WriteLine("JobDescriptor:" + JobDescriptor);
			var JobArea = BogusGenerator.JobArea();
			Console.WriteLine("JobArea:" + JobArea);
			var JobType = BogusGenerator.JobType();
			Console.WriteLine("JobType:" + JobType);
			var PhoneNumber = BogusGenerator.PhoneNumber("## ### ####");
			Console.WriteLine("PhoneNumber:" + PhoneNumber);
			var PhoneNumberFormat = BogusGenerator.PhoneNumberFormat(0);
			Console.WriteLine("PhoneNumberFormat:" + PhoneNumberFormat);
			var Review = BogusGenerator.Review("product");
			Console.WriteLine("Review:" + Review);
			var Reviews = BogusGenerator.Reviews("product", 2);
			Console.WriteLine("Reviews:" + Reviews);
			var FileName = BogusGenerator.FileName(".txt");
			Console.WriteLine("FileName:" + FileName);
			var DirectoryPath = BogusGenerator.DirectoryPath();
			Console.WriteLine("DirectoryPath:" + DirectoryPath);
			var FilePath = BogusGenerator.FilePath();
			Console.WriteLine("FilePath:" + FilePath);
			var CommonFileName = BogusGenerator.CommonFileName(".txt");
			Console.WriteLine("CommonFileName:" + CommonFileName);
			var MimeType = BogusGenerator.MimeType();
			Console.WriteLine("MimeType:" + MimeType);
			var CommonFileType = BogusGenerator.CommonFileType();
			Console.WriteLine("CommonFileType:" + CommonFileType);
			var CommonFileExt = BogusGenerator.CommonFileExt();
			Console.WriteLine("CommonFileExt:" + CommonFileExt);
			var FileType = BogusGenerator.FileType();
			Console.WriteLine("FileType:" + FileType);
			var FileExt = BogusGenerator.FileExt(".txt");
			Console.WriteLine("FileExt:" + FileExt);
			var Semver = BogusGenerator.Semver();
			Console.WriteLine("Semver:" + Semver);
			var Version = BogusGenerator.Version();
			Console.WriteLine("Version:" + Version);
			var Exception = BogusGenerator.Exception();
			Console.WriteLine("Exception:" + Exception);
			var AndroidId = BogusGenerator.AndroidId();
			Console.WriteLine("AndroidId:" + AndroidId);
			var ApplePushToken = BogusGenerator.ApplePushToken();
			Console.WriteLine("ApplePushToken:" + ApplePushToken);
			var BlackBerryPin = BogusGenerator.BlackBerryPin();
			Console.WriteLine("BlackBerryPin:" + BlackBerryPin);

		}
	}
}
