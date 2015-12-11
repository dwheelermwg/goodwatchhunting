//
//  ExtensionDelegate.swift
//  GoodWatchHuntingApp WatchKit Extension
//
//  Created by Derek Wheeler on 12/9/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import WatchKit
import HealthKit

class ExtensionDelegate: NSObject, WKExtensionDelegate {

    func applicationDidFinishLaunching() {
        print("Watch extension has started.")
        
        let healthStore = HKHealthStore()
        guard HKHealthStore.isHealthDataAvailable() else {
            return
        }
        
        let dataTypes = Set([
            HKQuantityType.quantityTypeForIdentifier(HKQuantityTypeIdentifierHeartRate)!,
            HKQuantityType.quantityTypeForIdentifier(HKQuantityTypeIdentifierStepCount)!
        ])
        healthStore.requestAuthorizationToShareTypes(nil, readTypes: dataTypes, completion: { (result, error) -> Void in
            if result {
                print("HealthKit authorization successful!")
            } else {
                print("HealthKit authorization failed!")
            }
        })
        // Perform any final initialization of your application.
    }

    func applicationDidBecomeActive() {
        // Restart any tasks that were paused (or not yet started) while the application was inactive. If the application was previously in the background, optionally refresh the user interface.
    }

    func applicationWillResignActive() {
        // Sent when the application is about to move from active to inactive state. This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) or when the user quits the application and it begins the transition to the background state.
        // Use this method to pause ongoing tasks, disable timers, etc.
    }

}
